using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ERP.Domain.Entities;

namespace ERP.Infrastructure.Context;

public class ERPDBContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{

    public ERPDBContext(DbContextOptions<ERPDBContext> options) : base(options)
    {
    }
    public DbSet<ApplicationUser> Users { get; set; }

    public DbSet<UserRefreshTokens> UserRefreshToken { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
