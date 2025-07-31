using ERP.Domain.Common;
using ERP.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERP.Infrastructure.Persistence.Configurations.WriteModels;

internal class BaseWriteConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    protected readonly ValueConverter<BaseId, int> baseIdConverter =
        new(a => a.Value, a => new BaseId(a));

    protected readonly ValueConverter<RowId, Guid> rowIdConverter =
        new(a => a.Value, a => new RowId(a));

    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        // _id property
        builder.Property<BaseId>("_id")
               .HasField("_id")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasConversion(baseIdConverter)
               .HasColumnName("Id");


        builder.HasKey("_id");

        // _rowId property
        builder.Property(typeof(RowId), "_rowId")
               .HasField("_rowId")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasConversion(rowIdConverter)
               .HasColumnName("RowId");

        // _isDeleted property
        builder.Property(typeof(bool), "_isDeleted")
               .HasField("_isDeleted")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("IsDeleted");

        // _createdAt property
        builder.Property(typeof(DateTime), "_createdAt")
               .HasField("_createdAt")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("CreatedAt");

        // _updatedAt property
        builder.Property(typeof(DateTime?), "_updatedAt")
               .HasField("_updatedAt")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("UpdatedAt");
    }
}

