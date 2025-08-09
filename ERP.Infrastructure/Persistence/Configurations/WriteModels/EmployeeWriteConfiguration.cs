using ERP.Domain.Entities;
using ERP.Domain.Enums;
using ERP.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using static ERP.Infrastructure.Persistence.Configurations.SqlDataTypes;

namespace ERP.Infrastructure.Persistence.Configurations.WriteModels;

internal sealed class EmployeeWriteConfiguration : BaseWriteConfiguration<Employee>
{
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

        builder.ToTable("Employee", "api");

        var firstNameConverter = new ValueConverter<FirstName, string>(
            fn => fn.Value,
            str => new FirstName(str));

        var lastNameConverter = new ValueConverter<LastName, string>(
            ln => ln.Value,
            str => new LastName(str));

        var nationalCodeConverter = new ValueConverter<NationalCode, string>(
            nc => nc.Value,
            str => new NationalCode(str));

        var birthDateConverter = new ValueConverter<BirthDate, DateTime>(
            bd => bd.Value,
            dt => new BirthDate(dt));


        builder.Property(typeof(FirstName), "_firstName")
            .HasConversion(firstNameConverter)
            .HasColumnName("FirstName")
            .HasColumnType(NVARCHAR(250))
            .IsRequired();

        builder.Property(typeof(LastName), "_lastName")
            .HasConversion(lastNameConverter)
            .HasColumnName("LastName") 
            .HasColumnType(NVARCHAR(250))
            .IsRequired();

        builder.Property(typeof(NationalCode), "_nationalCode")
            .HasConversion(nationalCodeConverter)
            .HasColumnName("NationalCode")
            .HasColumnType(NVARCHAR(12))
            .IsRequired();

        builder.Property(typeof(BirthDate), "_birthDateUtc")
            .HasConversion(birthDateConverter)
            .HasColumnName("BirthDateUtc")
            .HasColumnType(DATETIME)
            .IsRequired();

        builder.Property(typeof(EmployeePosition), "_employeePosition")
            .HasColumnName("EmployeePosition")
            .HasColumnType(TINYINT) 
            .IsRequired();

        builder.Property<int>("_companyId")
            .HasColumnName("CompanyId")
            .HasColumnType(INT)
            .IsRequired();
        
        builder.Property<DegreeLevel?>("_degreeLevel")
            .HasColumnName("DegreeLevel")
            .HasColumnType(TINYINT)
            .IsRequired(false); 

    }
}

