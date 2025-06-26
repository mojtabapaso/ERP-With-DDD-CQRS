using Microsoft.Extensions.DependencyInjection;

namespace ERP.Infrastructure.IocConfig;

public static class MemoryCacheServices
{
	public static IServiceCollection CacheServices(this IServiceCollection Services)
	{
		Services.AddMemoryCache();
		return Services;
	}
}
