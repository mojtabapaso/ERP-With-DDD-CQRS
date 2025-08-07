using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static ERP.Infrastructure.Persistence.Configurations.SqlDataTypes;
namespace ERP.Infrastructure.EFCore.Configurations;

public class  AuditLogConfiguration : IEntityTypeConfiguration<Audit>
{
    public void Configure(EntityTypeBuilder<Audit> builder)
    {
        builder.ToTable("Audit", "log");

        //builder.HasOne(e => e.User)
        //                .WithMany()
        //                .HasForeignKey(e => e.UserId)
        //                .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Timestamp).HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.ActionType).HasColumnType(TINYINT).HasConversion<byte>();
        builder.Property(x => x.EntityName).HasColumnType(NVARCHAR(100)).IsRequired();
        builder.Property(x => x.NewValues).HasColumnType(NVARCHAR_MAX);
        builder.Property(x => x.OldValues).HasColumnType(NVARCHAR_MAX);
    }
}