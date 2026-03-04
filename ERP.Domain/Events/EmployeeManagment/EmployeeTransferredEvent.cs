using ERP.Domain.DomainEvents;
using ERP.Domain.Entities;
using ERP.Domain.Enums;

namespace ERP.Domain.Events.EmployeeManagment;

public record EmployeeTransferredEvent(Guid AggregateId,int newCompany,int oldCompanyId, EmployeePosition EmployeePosition) : DomainEvent<Employee>(AggregateId);
