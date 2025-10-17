using ERP.Domain.Entities;
using ERP.Domain.Repository;
using ERP.Domain.Repository.EmployeeManagment;
using ERP.Domain.ValueObjects;
using ERP.Infrastructure.Generic;
using ERP.Infrastructure.Persistence;
using ERP.Infrastructure.Persistence.Contaxt;

namespace ERP.Infrastructure.Repository.EmployeeManagment;

public class EmployeeWriteRepository : GenericWriteRepository<Employee>, IEmployeeWriteRepository
{
    public EmployeeWriteRepository(WriteDbContext context) : base(context)
    {
    }

}

public class CompanyWriteRepository : GenericWriteRepository<Company> , ICompanyWriteRepository
{
    public CompanyWriteRepository(WriteDbContext context) : base(context) { }


}
