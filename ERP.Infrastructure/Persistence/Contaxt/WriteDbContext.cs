using ERP.Application.Interfaces;
using ERP.Domain.Entities;
using ERP.Domain.Entities.User;
using ERP.Domain.ValueObjects;
using ERP.Infrastructure.EFCore.Configurations;
using ERP.Infrastructure.Persistence.Configurations.WriteModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Contaxt;


public class WriteDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    private readonly IUserContextService userContext;
    private readonly IAuditService auditService;

    public WriteDbContext(DbContextOptions<WriteDbContext> options, IUserContextService userContext, IAuditService auditService) : base(options)
    {
        this.userContext = userContext;
        this.auditService = auditService;
    }
    public WriteDbContext(DbContextOptions<WriteDbContext> options)
    : base(options)
    {

    }

    // Auth
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<ApplicationRole> Roles { get; set; }
    //public DbSet<UserRefreshTokens> UserRefreshToken { get; set; }
    // ERP Entities
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeSalary> employeeSalaries { get; set; }
    //public DbSet<Department> Departments { get; set; }
    //public DbSet<Product> Products { get; set; }
    //public DbSet<Invoice> Invoices { get; set; }
    //public DbSet<InvoiceItem> InvoiceItems { get; set; }
    //public DbSet<Customer> Customers { get; set; }
    public DbSet<Audit> AuditLogs { get; set; }
    public DbSet<EntityOutbox> EntityOutboxes { get; set; }
    public DbSet<Company> Companies { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new AuditLogConfiguration());
        builder.ApplyConfiguration(new EmployeeWriteConfiguration());
        builder.ApplyConfiguration(new EmployeeSalaryWriteConfiguration());
        builder.ApplyConfiguration(new CompanyWriteConfiguration());
        builder.Ignore<BaseId>();
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var auditEntries = userContext != null
            ? auditService.PrepareAuditEntries(ChangeTracker, userContext.UserId)
            : new List<AuditEntry>();

        var result = await base.SaveChangesAsync(cancellationToken);

        if (userContext != null)
            await auditService.SaveAuditLogsAsync(this, auditEntries);

        return result;
    }
}
