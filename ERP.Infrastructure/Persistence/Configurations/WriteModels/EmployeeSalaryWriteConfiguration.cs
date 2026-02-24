using ERP.Domain.Entities;
using ERP.Domain.Enums;
using ERP.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERP.Infrastructure.Persistence.Configurations.WriteModels;

internal sealed class EmployeeSalaryWriteConfiguration : BaseWriteConfiguration<EmployeeSalary>
{
    ValueConverter idConverter = new ValueConverter<BaseId, int>(id => id.Value, id => new BaseId(id));

    ValueConverter amountConverter = new ValueConverter<AmountValueObject, int>(a => a.Value, a => new AmountValueObject(a));
    public override void Configure(EntityTypeBuilder<EmployeeSalary> builder)
    {
        base.Configure(builder);

        builder.ToTable("EmployeeSalary", "api");

        builder.Property(typeof(AmountValueObject), "_amount")
            .HasConversion(amountConverter)
            .HasColumnName("Amount");

        builder.Property(typeof(BaseId), "_employeeId")
            .HasConversion(idConverter)
            .HasColumnName("EmployeeId");

        builder.Property(typeof(DateTime), "_periodStart")
            .HasColumnName("PeriodStart");

        builder.Property(typeof(DateTime), "_periodEnd")
            .HasColumnName("PeriodEnd");

        builder.Property(typeof(AmountValueObject), "_basicSalary")
            .HasConversion(amountConverter)
            .HasColumnName("BasicSalary"); 

        builder.Property(typeof(AmountValueObject), "_taxAmount")
            .HasConversion(amountConverter)
            .HasColumnName("TaxAmount");

        builder.Property(typeof(SalaryPaymentStatus), "_paymentStatus")
            .HasColumnName("PaymentStatus");

        builder.Property(typeof(DateTime?), "_paymentDate")
            .HasColumnName("PaymentDate");
    }

}

