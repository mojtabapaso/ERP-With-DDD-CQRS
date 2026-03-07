using MediatR;

namespace ERP.Domain.Events.EmployeeManagment;

public record EmployeeResignedEvent(Guid AggregateId, int EmployeeId, string reason, DateTime resignationDate) : INotification;