using ERP.Application.Configurations;
using ERP.Infrastructure.Persistence.Contaxt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Infrastructure.IocConfig;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ReadDbContext>();

        // 1. Bind config sections
        //services.Configure<AzureAdSettings>(
        //    configuration.GetSection("AzureAd"));
        //services.Configure<JwtSettings>(
        //    configuration.GetSection("Jwt"));
        services.Configure<ConnectionStringsSettings>(
            configuration.GetSection("ConnectionStrings"));

        // 2. DbContext registration (مثال)
        //var conn = configuration
        //    .GetSection("ConnectionStrings")
        //    .Get<ConnectionStringsSettings>()
        //    .ConnectionWrite;
        //services.AddDbContext<EFCore.AppDbContext>(opt =>
        //    opt.UseSqlServer(conn));

        // 3. هر سرویس دیگری مثل MediatR, Identity, Caching و…
        // services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(...));

        return services;
    }
}