using Microsoft.Extensions.DependencyInjection;
using ERP.Application.Mappings;

namespace ERP.Infrastructure.IocConfig;
public static class AutoMapperServies
{
	public static IServiceCollection AddAutoMapperServies(this IServiceCollection Services)
	{
		Services.AddAutoMapper(typeof(MappingProfile));
		return Services;
	}
}
