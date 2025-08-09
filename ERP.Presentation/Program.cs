using Asp.Versioning;
using ERP.Infrastructure.IocConfig;
using ERP.Presentation.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var Services = builder.Services;

Services.AddControllers();
Services.AddEndpointsApiExplorer();
Services.AddSwaggerGen();
Services.AddRepositoryServies();
Services.AddResponseCaching();
Services.AddMemoryCache();
Services.AddAutoMapperServies();

Services.AddAuditServies();
Services.AddInfrastructureServices(builder.Configuration);
Services.AddMedaitRConfig();
Services.AddDbContextServies(builder.Configuration);
Services.AddIdentityServies();
Services.AddLogicServies();

Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseResponseCaching();

app.UseRouting();

app.UseCors("EnableCors");  // اگر نیاز به CORS داری، فعال کن

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
