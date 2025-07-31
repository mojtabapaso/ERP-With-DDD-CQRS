using ERP.Domain.Entities;
using ERP.Domain.Repository.EmployeeManagment;
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