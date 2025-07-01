using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ERP.Infrastructure.Persistence.DesignTimeFactories;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public ApplicationDbContextFactory()
    {
    }
    public AppDbContext CreateDbContext(string[] args)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
        IConfigurationRoot root = builder.Build();
        string? sqlConnectionString = root["ConnectionStrings:ERPDBConecnection"];
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(sqlConnectionString);
        return new AppDbContext(optionsBuilder.Options);
    }
}
