using ERP.Domain.Common;
using ERP.Domain.Entities;
using ERP.Domain.Enums;
using ERP.Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace ERP.Infrastructure.Persistence.Context;


public class ERPDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public ERPDBContext(DbContextOptions<ERPDBContext> options) : base(options)
    {
    }
    // Auth
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<UserRefreshTokens> UserRefreshToken { get; set; }
    public DbSet<UserRefreshToken> userRefreshTokens { get; set; }
    // ERP Entities
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Audit> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new AuditLogConfiguration());


        // اگر نیاز به تنظیمات خاص مثل Fluent API داری، اینجا تعریف کن
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.IsDeleted = false;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
