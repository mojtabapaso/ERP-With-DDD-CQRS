using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations.ReadModels;

public abstract class BaseReadEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        //builder.HasKey(e => e.Id);

        //    builder.Property(e => e.RowId)
        //        .IsRequired()
        //        .HasDefaultValueSql("NEWID()");

        //    builder.Property(e => e.IsDeleted)
        //        .IsRequired()
        //        .HasDefaultValue(false);

        //    builder.Property(e => e.CreatedAt)
        //        .IsRequired()
        //        .HasDefaultValueSql("GETUTCDATE()");

        //    builder.Property(e => e.UpdatedAt)
        //        .IsRequired(false);

        //    builder.HasIndex(e => e.RowId)
        //        .IsUnique();

        //    builder.HasIndex(e => e.IsDeleted);


    }
}