using Microsoft.Extensions.DependencyInjection;

namespace ERP.Domain.Attributes;

[AttributeUsage(AttributeTargets.Interface)]
public class AutoRegisterAttribute : Attribute
{
    public ServiceLifetime Lifetime { get; }

    public AutoRegisterAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        Lifetime = lifetime;
    }
}

