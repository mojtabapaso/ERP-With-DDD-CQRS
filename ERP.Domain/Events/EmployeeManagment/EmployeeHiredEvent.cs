using MediatR;

namespace ERP.Domain.Events.EmployeeManagment;

//public record EmployeeHiredEvent(Guid AggregateId, int employeeId,int companyId, string fullName, EmployeePosition employeePosition) : DomainEvent<Employee>(AggregateId);
public sealed record EmployeeHiredEvent(Guid employeeId) : INotification; //: DomainEvent<Employee>();`
