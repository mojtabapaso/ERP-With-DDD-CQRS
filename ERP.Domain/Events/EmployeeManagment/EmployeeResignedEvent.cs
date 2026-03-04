using ERP.Domain.DomainEvents;
using ERP.Domain.Entities;

namespace ERP.Domain.Events.EmployeeManagment;

public record EmployeeResignedEvent(Guid AggregateId,int EmployeeId,string reason , DateTime resignationDate) : DomainEvent<Employee>(AggregateId);