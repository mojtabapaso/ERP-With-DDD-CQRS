using MediatR;

namespace ERP.Domain.Events.EmployeeManagment;

public record LeaveApprovedEvent(Guid AggregateId, int EmployeeId, int leaveRequestId) : INotification;
