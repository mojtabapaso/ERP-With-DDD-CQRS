using ERP.Domain.Entities;
using ERP.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERP.Infrastructure.Persistence.Configurations.WriteModels;

internal sealed  class CompanyWriteConfiguration : BaseWriteConfiguration<Company>
{
    ValueConverter nameConverter = new ValueConverter<Name, string>(c => c.Value, c => new Name(c));
    public override void Configure(EntityTypeBuilder<Company> builder)
    {
        base.Configure(builder);
        builder.ToTable("Company", "api");
        builder.Property(typeof(Name), "_name").HasConversion(nameConverter).HasColumnName("Name").HasColumnType("NVARCHAR(250)");
    }
}

