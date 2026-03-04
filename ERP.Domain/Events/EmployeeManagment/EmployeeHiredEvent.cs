using ERP.Domain.DomainEvents;
using ERP.Domain.Entities;
using ERP.Domain.Enums;

namespace ERP.Domain.Events.EmployeeManagment;

public record EmployeeHiredEvent(Guid AggregateId, int employeeId,int companyId, string fullName, EmployeePosition employeePosition) : DomainEvent<Employee>(AggregateId);
