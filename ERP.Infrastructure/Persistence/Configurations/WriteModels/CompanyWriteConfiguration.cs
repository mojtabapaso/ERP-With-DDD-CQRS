using ERP.Domain.Entities;
using ERP.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERP.Infrastructure.Persistence.Configurations.WriteModels;

internal sealed class CompanyWriteConfiguration : BaseWriteConfiguration<Company>
{

    public override void Configure(EntityTypeBuilder<Company> builder)
    {
        var nameConverter = new ValueConverter<NameValueObject, string>
          (c => c.Value, c => new NameValueObject(c));
        var taxCodeConverter = new ValueConverter<TaxCodeValueObject, string>
            (c => c.Value, c => new TaxCodeValueObject(c));
        var phoneNumberConverter = new ValueConverter<PhoneNumberValueObject, string>
            (c => c.Value, c => new PhoneNumberValueObject(c));
        var addressConverter = new ValueConverter<AddressValueObject, string>
            (c => c.Value, c => new AddressValueObject(c));
        base.Configure(builder);
        builder.ToTable("Company", "api");
        //Name
        builder.Property(typeof(NameValueObject), "_name")
                .HasConversion(nameConverter)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR(250)");
        //TaxCode
        builder.Property(typeof(TaxCodeValueObject), "_taxCode")
            .HasConversion(taxCodeConverter)
            .HasColumnName("TaxCode")
            .HasColumnType("NVARCHAR(100)");
        //PhoneNumber
        builder.Property(typeof(PhoneNumberValueObject), "_phoneNumber")
                .HasConversion(phoneNumberConverter)
                .HasColumnName("PhoneNumber")
                .HasColumnType("NVARCHAR(250)");
        //Address
        builder.Property(typeof(AddressValueObject), "_address")
                .HasConversion(addressConverter)
                .HasColumnName("Address")
                .HasColumnType("NVARCHAR(500)");


    }
}

