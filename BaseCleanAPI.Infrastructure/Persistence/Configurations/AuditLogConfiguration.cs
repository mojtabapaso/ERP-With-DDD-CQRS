using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<Audit>
{
    public void Configure(EntityTypeBuilder<Audit> builder)
    {
        builder.ToTable("Audit", "Log");

        builder.HasOne(e => e.User)
                        .WithMany()
                        .HasForeignKey(e => e.UserId)
                        .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Timestamp).HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.ActionType).HasColumnType("TINYINT").HasConversion<byte>();
        builder.Property(x => x.EntityName).HasColumnType("NVARCHAR(100)").IsRequired();
        builder.Property(x => x.NewValues).HasColumnType("nvarchar(max)");
        builder.Property(x => x.OldValues).HasColumnType("nvarchar(max)");

    }
}