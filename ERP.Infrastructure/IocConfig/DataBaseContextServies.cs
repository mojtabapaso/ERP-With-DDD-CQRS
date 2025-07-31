using ERP.Infrastructure.Persistence.Contaxt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Infrastructure.IocConfig;

public static class DataBaseContextServices
{
    public static IServiceCollection AddDbContextServies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WriteDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionWrite")));
        return services;
    }
}
