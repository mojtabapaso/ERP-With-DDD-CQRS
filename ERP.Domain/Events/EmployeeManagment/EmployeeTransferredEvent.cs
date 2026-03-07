using ERP.Domain.DomainEvents;
using ERP.Domain.Entities;
using ERP.Domain.Enums;
using MediatR;

namespace ERP.Domain.Events.EmployeeManagment;

public record EmployeeTransferredEvent(Guid AggregateId,int newCompany,int oldCompanyId, EmployeePosition EmployeePosition) : INotification;
