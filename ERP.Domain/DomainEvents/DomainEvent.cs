using ERP.Domain.Entities;
using ERP.Shared.Abstraction.Domain;

namespace ERP.Domain.DomainEvents;


// TODO Deleted 
public abstract record DomainEvent<TEntity>(Guid AggregateId) : IDomainEvent
{
    public int Version { get; init; } = 1;
    public string AggregateType { get; init; } = typeof(TEntity).Name;
    public string EventType { get; init; } 
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTimeOffset OccurredOnUtc { get; init; } = DateTimeOffset.UtcNow;
    public string? TraceInfo { get; init; }
    //protected DomainEvent() : this(Guid.NewGuid())
    //{
    //    EventType = GetType().Name;  
    //}

}
