using ERP.Application;
using ERP.Application.MediatR;
using ERP.Domain;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ERP.Infrastructure.IocConfig;

public static class MediatRConfig
{
    public static IServiceCollection AddMedaitRConfig(this IServiceCollection Service)
    {
        Service.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
            cfg.RegisterServicesFromAssemblies(typeof(ApplicationAssemblyReference).Assembly);
            cfg.RegisterServicesFromAssemblies(typeof(DomianAssemblyReference).Assembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        Service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        return Service;
    }

}
