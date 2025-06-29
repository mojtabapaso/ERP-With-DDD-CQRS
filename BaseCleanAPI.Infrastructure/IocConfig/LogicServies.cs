using Microsoft.Extensions.DependencyInjection;
using ERP.Infrastructure.Authentication.Interfaces;
using ERP.Infrastructure.Authentication.Services;

namespace ERP.Infrastructure.IocConfig;

public static class LogicServies
{
	public static IServiceCollection AddLogicServies(this IServiceCollection Services)
	{
		Services.AddScoped<IJWTManager, JWTManager>();
		return Services;
	}
}