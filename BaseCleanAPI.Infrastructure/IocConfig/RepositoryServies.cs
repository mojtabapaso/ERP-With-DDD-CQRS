using Microsoft.Extensions.DependencyInjection;
using ERP.Infrastructure.Services;

namespace ERP.Infrastructure.IocConfig;

/// <summary>
/// Extension to register repositories.
/// </summary>
public static class RepositoryServies
{
    /// <summary>
    /// Add repository services to DI.
    /// </summary>
    public static IServiceCollection AddRepositoryServies(this IServiceCollection Services)
    {
        // Register services here
        return Services;
    }
}
