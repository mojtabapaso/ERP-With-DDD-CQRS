using ERP.Domain.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ERP.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        var types = typeof(InfrastructureAssemblyReference).Assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract);

        foreach (var type in types)
        {
            var directInterfaces = type.GetInterfaces()
                .Where(i => i.GetCustomAttribute<AutoRegisterAttribute>() != null).FirstOrDefault();

            if (directInterfaces is not null)
            {
                var attr = directInterfaces.GetCustomAttribute<AutoRegisterAttribute>();
                services.Add(new ServiceDescriptor(directInterfaces, type, attr.Lifetime));
            }
        }

        return services;
    }

}
