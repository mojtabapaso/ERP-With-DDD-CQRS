using ERP.Domain.Entities;
using ERP.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERP.Infrastructure.Persistence.Configurations.WriteModels;

internal sealed class EmployeeWriteConfiguration : BaseWriteConfiguration<Employee>
{
    public override void Configure(EntityTypeBuilder<Employee> builder)
    {
        base.Configure(builder);
        Console.WriteLine("Employee configuration executed.");
        var firstNameConverter = new ValueConverter<FirstName, string>(fn => fn.Value, fn => new FirstName(fn));
        builder.ToTable("Employee", "api");
        builder.Property(typeof(FirstName), "_firstName")
            .HasConversion(firstNameConverter).HasColumnName("FirstName").IsRequired();

    }
}

