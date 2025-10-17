using ERP.Domain.Entities;

namespace ERP.Domain.Repository.EmployeeManagment;

public interface IEmployeeWriteRepository : IGenericWriteRepository<Employee>
{
}


public interface ICompanyWriteRepository : IGenericWriteRepository<Company>
{

}