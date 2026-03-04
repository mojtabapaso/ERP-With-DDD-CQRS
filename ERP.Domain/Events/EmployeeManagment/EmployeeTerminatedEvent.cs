using ERP.Domain.DomainEvents;
using ERP.Domain.Entities;

namespace ERP.Domain.Events.EmployeeManagment;

public record EmployeeTerminatedEvent(Guid AggregateId,int EmployeeId,string FullName,string Reason,DateTime TerminationDate,  int CompanyId) : DomainEvent<Employee>(AggregateId);
