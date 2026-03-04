using ERP.Domain.Entities;

namespace ERP.Domain.DomainEvents;
public record NewEmployeeCreated(Guid EmployeeId, string FirstName, string LastName, int CompanyId) : DomainEvent<Employee>(EmployeeId);
