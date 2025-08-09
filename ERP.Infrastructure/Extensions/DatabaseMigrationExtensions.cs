using ERP.Infrastructure.Persistence.Contaxt;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.Extensions;

public static class DatabaseMigrationExtensions
{
    public static void ApplyDatabaseMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<InfrastructureAssemblyReference>>();
        var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();
        var db = scope.ServiceProvider.GetRequiredService<WriteDbContext>();

        var pendingMigrations = db.Database.GetPendingMigrations().ToList();

        if (pendingMigrations.Any())
        {
            logger.LogWarning("Pending migrations detected: {Migrations}", pendingMigrations);

            if (env.IsDevelopment())
            {
                logger.LogInformation("Applying migrations automatically...");
                db.Database.Migrate();
                logger.LogInformation("Migrations applied successfully.");
            }
            else
            {
                logger.LogError("Production environment detected. Pending migrations must be applied manually!");
                throw new Exception("Pending migrations found in Production! Apply them before running the app.");
            }
        }
        else
        {
            logger.LogInformation("Database is up-to-date. No pending migrations.");
        }
    }
}
