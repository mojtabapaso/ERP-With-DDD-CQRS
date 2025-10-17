using ERP.Infrastructure.Persistence.Models.EmployeeManagment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations.ReadModels;


//internal  class EmployeeReadConfiguration : BaseReadEntityConfiguration<EmployeeReadModel>
//{
//    public virtual void Configure(EntityTypeBuilder<EmployeeReadModel> builder)
//    {
//        base.Configure(builder);

//        builder.ToTable("Employee", "api");


//        builder.Property(e => e.FirstName)
//               .HasColumnType("NVARCHAR(100)")
//               .IsRequired();

//        builder.Property(e => e.LastName)
//               .HasColumnType("NVARCHAR(100)")
//               .IsRequired();

//        builder.Property(e => e.NationalCode)
//               .HasColumnType("NVARCHAR(15)");

//        builder.HasIndex(x => x.NationalCode).IsUnique();

//        //builder.Property(e => e.Position)
//        //       .HasConversion<string>()
//        //       .HasColumnType("NVARCHAR(100)")
//        //       .IsRequired();

//        builder.HasOne(e => e.Company)
//               .WithMany(c => c.Employees)
//               .HasForeignKey(e => e.CompanyId);
//    }
//}
