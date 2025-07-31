using ERP.Application;
using ERP.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ERP.Infrastructure.IocConfig;

public static class MediatRConfig
{
    public static IServiceCollection AddMedaitRConfig(this IServiceCollection Service)
    {
        Service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ApplicationAssemblyReference).Assembly));
        Service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DomianAssemblyReference).Assembly));
        //Service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(PresentationAssemblyReference).Assembly));

        return Service;
    }

}
