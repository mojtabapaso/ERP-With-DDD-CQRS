using ERP.Domain.Common;
using ERP.Shared.Abstraction.Domain;
using MediatR;

namespace ERP.Domain.AggregateRoots;

public abstract class AggregateRoot<TEntity> : BaseEntity
{
    
    
    private readonly List<INotification> _domainEvents = new();
    
    public IReadOnlyCollection<INotification> DomainEvents => 
        _domainEvents.AsReadOnly();

    protected void AddDomainEvent(INotification domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    
    protected void RemoveDomainEvent(INotification domainEvent)
    {   
        _domainEvents.Remove(domainEvent);
    }
    
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
