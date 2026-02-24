using ERP.Domain.Entities;
using ERP.Shared.Abstraction.Domain;

namespace ERP.Domain.DomainEvents;


public abstract record DomainEvent<TEntity>(Guid AggregateId) : IDomainEvent
{
    public int Version { get; init; } = 1;
    public string AggregateType { get; init; } = typeof(TEntity).Name;
    public string EventType { get; init; } 
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTimeOffset OccurredOnUtc { get; init; } = DateTimeOffset.UtcNow;
    public string? TraceInfo { get; init; }
    protected DomainEvent() : this(Guid.NewGuid())
    {
        EventType = GetType().Name;  
    }

}
public record NewEmployeeCreated(Guid EmployeeId, string FirstName, string LastName, int CompanyId) : DomainEvent<Employee>(EmployeeId);
