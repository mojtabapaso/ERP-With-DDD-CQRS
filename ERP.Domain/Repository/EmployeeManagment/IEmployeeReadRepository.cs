using ERP.Domain.Entities;

namespace ERP.Domain.Repository.EmployeeManagment;

public interface IEmployeeReadRepository
{
    Task<Employee> GetByRowIdAsync(Guid guid, CancellationToken cancellation);
}
