using ERP.Domain.Repository.EmployeeManagment;
using ERP.Infrastructure.Repository.EmployeeManagment;
using Microsoft.Extensions.DependencyInjection;
//using ERP.Infrastructure.Services;

namespace ERP.Infrastructure.IocConfig;

/// <summary>
/// Extension to register repositories.
/// </summary>
public static class RepositoryServies
{
    /// <summary>
    /// Add repository services to DI.
    /// </summary>
    public static IServiceCollection AddRepositoryServies(this IServiceCollection Service)
    {
        Service.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();
        Service.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();

        //Service.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();

        return Service;
    }
}
