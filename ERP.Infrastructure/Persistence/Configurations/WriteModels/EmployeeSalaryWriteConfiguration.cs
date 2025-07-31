using ERP.Domain.Entities;
using ERP.Domain.Enums;
using ERP.Domain.ValueObjects;
using ERP.Domain.ValueObjects.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERP.Infrastructure.Persistence.Configurations.WriteModels;

internal sealed class EmployeeSalaryWriteConfiguration : BaseWriteConfiguration<EmployeeSalary>
{
    ValueConverter idConverter = new ValueConverter<BaseId,int>( id => id.Value ,id=> new BaseId(id));

    ValueConverter amountConverter = new ValueConverter<Amount, int>(a => a.Value, a => new Amount(a));
    public override void Configure(EntityTypeBuilder<EmployeeSalary> builder)
    {
        builder.ToTable("EmployeeSalary", "api");

        builder.Property(typeof(Amount), "_amount").HasConversion(amountConverter).HasColumnName("Amount");
        builder.Property(typeof(BaseId), "_employeeId").HasConversion(idConverter).HasColumnName("EmployeeId");
        builder.Property(typeof(DateTime), "_periodStart").HasColumnName("PeriodStart");
        builder.Property(typeof(DateTime), "_periodEnd").HasColumnName("PeriodEnd");

        builder.Property(typeof(Amount), "_basicSalary").HasConversion(amountConverter).HasColumnName("EmployeeId");
        //builder.Property(typeof(Amount), "_allowances").HasConversion(amountConverter).HasColumnName("EmployeeId");
        //builder.Property(typeof(Amount), "_deductions").HasConversion(amountConverter).HasColumnName("EmployeeId");
        //builder.Property(typeof(Amount), "_bonuses").HasConversion(amountConverter).HasColumnName("EmployeeId");
        builder.Property(typeof(Amount), "_taxAmount").HasConversion(amountConverter).HasColumnName("TaxAmount");
        builder.Property(typeof(SalaryPaymentStatus), "_paymentStatus").HasColumnName("PaymentStatus");
        builder.Property(typeof(DateTime?), "_paymentDate").HasColumnName("PaymentDate");

    }

}

