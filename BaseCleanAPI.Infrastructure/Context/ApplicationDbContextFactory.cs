using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ERP.Infrastructure.Context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ERPDBContext>
{
    public ApplicationDbContextFactory()
    {
    }
    public ERPDBContext CreateDbContext(string[] args)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
        IConfigurationRoot root = builder.Build();
        string? sqlConnectionString = root["ConnectionStrings:ERPDBConecnection"];
        var optionsBuilder = new DbContextOptionsBuilder<ERPDBContext>();
        optionsBuilder.UseSqlServer(sqlConnectionString);
        return new ERPDBContext(optionsBuilder.Options);
    }
}
