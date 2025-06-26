using Microsoft.Extensions.DependencyInjection;
using ERP.Application.Interface.Logic;
using ERP.Application.Services;

namespace ERP.Infrastructure.IocConfig;

public static class LogicServies
{
	public static IServiceCollection AddLogicServies(this IServiceCollection Services)
	{
		Services.AddScoped<IJWTManager, JWTManager>();
		return Services;
	}
}