using ERP.Domain.Entities;
using ERP.Shared.Abstraction.Domain;

namespace ERP.Domain.DomainEvents;

public record NewEmployeeCreated(Employee employee) : IDomainEvent;
