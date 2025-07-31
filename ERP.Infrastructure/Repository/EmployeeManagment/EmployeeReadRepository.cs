using ERP.Domain.Entities;
using ERP.Domain.Repository.EmployeeManagment;

namespace ERP.Infrastructure.Repository.EmployeeManagment;

public class EmployeeReadRepository : IEmployeeReadRepository
{
    public Task<Employee> GetByRowIdAsync(Guid guid, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }
}