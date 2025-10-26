using ERP.Domain.Attributes;
using ERP.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Domain.Repository.EmployeeManagment;

[AutoRegister(ServiceLifetime.Scoped)]
public interface IEmployeeWriteRepository : IGenericWriteRepository<Employee>
{
}

[AutoRegister(ServiceLifetime.Scoped)]
public interface ICompanyWriteRepository : IGenericWriteRepository<Company>
{

}