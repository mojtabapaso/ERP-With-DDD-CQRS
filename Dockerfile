FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["ERP.Presentation/ERP.Presentation.csproj", "ERP.Presentation/"]
COPY ["ERP.Application/ERP.Application.csproj", "ERP.Application/"]
COPY ["ERP.Domain/ERP.Domain.csproj", "ERP.Domain/"]
COPY ["ERP.Infrastructure/ERP.Infrastructure.csproj", "ERP.Infrastructure/"]
COPY ["ERP.Shared.Abstraction/ERP.Shared.Abstraction.csproj", "ERP.Shared.Abstraction/"]
COPY ["ERP.Shared.Common/ERP.Shared.Common.csproj", "ERP.Shared.Common/"]

RUN dotnet restore "ERP.Presentation/ERP.Presentation.csproj"

COPY . .

WORKDIR "/src/ERP.Presentation"

RUN dotnet build "ERP.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ERP.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ERP.Presentation.dll"]
