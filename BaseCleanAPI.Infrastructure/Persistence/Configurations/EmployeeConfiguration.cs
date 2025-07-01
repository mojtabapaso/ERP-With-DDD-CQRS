using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        
        builder.Property(e => e.FirstName)
               .HasColumnType("NVARCHAR(100)")
               .IsRequired();

        builder.Property(e => e.LastName)
               .HasColumnType("NVARCHAR(100)")
               .IsRequired();

        builder.Property(e => e.NationalCode)
               .HasColumnType("NVARCHAR(15)");

        builder.HasIndex(x => x.NationalCode).IsUnique();

        builder.Property(e => e.Position)
               .HasConversion<string>()
               .HasColumnType("NVARCHAR(100)")
               .IsRequired();

        builder.Property(e => e.BirthDate)
               .IsRequired();

        builder.HasOne(e => e.Company)
               .WithMany(c => c.Employees)
               .HasForeignKey(e => e.CompanyId);
    }
}
