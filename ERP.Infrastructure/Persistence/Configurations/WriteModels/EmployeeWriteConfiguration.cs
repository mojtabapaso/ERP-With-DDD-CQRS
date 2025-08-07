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

        //var firstNameConverter = new ValueConverter<FirstName, string>(fn => fn.Value, fn => new FirstName(fn));
        //var lastNameConverter = new ValueConverter<LastName, string>(ls => ls.Value, ls => new LastName(ls));
        //var nationalCodeConverter = new ValueConverter<NationalCode, string>(nc => nc.Value, nc => new NationalCode(nc));
        builder.ToTable("Employee", "api");

        // تعریف ValueConverter ها برای ValueObject ها
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

        // کانفیگ پراپرتی ها:

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
            .HasColumnType(TINYINT) // چون enum هست
            .IsRequired();

        builder.Property<int>("_companyId")
            .HasColumnName("CompanyId")
            .HasColumnType(INT)
            .IsRequired();

        //// رابطه با Company (اگر بخوایم مثلا FK بذاریم، باید جدا کانفیگ کنیم)
        //builder.HasOne(typeof(Company), "_company")
        //    .WithMany("Employees")  // فرض بر اینکه Company کلاسش یک ICollection<Employee> Employees دارد
        //    .HasForeignKey("_companyId")
        //    .OnDelete(DeleteBehavior.Restrict);

        // کانفیگ کلکسیون حقوق (اگر میخوایم Relation باشه)
        // builder.HasMany(typeof(EmployeeSalary), "_employeeSalary")
        //    .WithOne("Employee")
        //    .HasForeignKey("EmployeeId")
        //    .OnDelete(DeleteBehavior.Cascade);

        // اگر DegreeLevel Enum است:
        builder.Property<DegreeLevel?>("_degreeLevel")
            .HasColumnName("DegreeLevel")
            .HasColumnType(TINYINT)
            .IsRequired(false);  // فرض کنیم اختیاری است

    }
}

