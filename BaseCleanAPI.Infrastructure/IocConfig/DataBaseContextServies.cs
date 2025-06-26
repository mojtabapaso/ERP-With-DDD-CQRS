using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ERP.Infrastructure.Context;

namespace ERP.Infrastructure.IocConfig;

public static class DataBaseContextServies
{
	public static IServiceCollection AddDbContextServies(this IServiceCollection Services)
	{
		var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

		string connectionString = config["ConnectionStrings:ERPDBConecnection"];

		Services.AddDbContext<ERPDBContext>(option =>
		{
			option.UseSqlServer(connectionString);
		});
		return Services;
	}
}