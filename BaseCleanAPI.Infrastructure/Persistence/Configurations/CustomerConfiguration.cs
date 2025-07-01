using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Persistence.Configurations;

public class CustomerConfiguration:BaseEntityConfiguration<Customer>
{
    public virtual void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);

        builder.ToTable("Customer", "api");

        builder.Property(x=>x.Address).HasColumnType("NVARCHAR(500)");

        builder.Property(x => x.PhoneNumber).HasColumnType("NVARCHAR(11)").IsRequired();
        builder.HasIndex(x => x.PhoneNumber).IsUnique();

        builder.Property(x => x.Email).HasColumnType("NVARCHAR(500)");
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.FullName).HasColumnType("NVARCHAR(200)").IsRequired();

    }
}