using ERP.Domain.DomainEvents;
using ERP.Domain.Entities;

namespace ERP.Domain.Events.EmployeeManagment;

public record LeaveApprovedEvent(Guid AggregateId,int EmployeeId, int leaveRequestId) : DomainEvent<Employee>(AggregateId);
