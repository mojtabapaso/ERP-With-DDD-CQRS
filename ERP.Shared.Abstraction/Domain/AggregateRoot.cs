namespace ERP.Shared.Abstraction.Domain;

//public abstract class AggregateRoot<TEntity>  where TEntity : ERP.Domain.Entities.BaseEntity
//{
//    //public T Id { get; protected set; }
//    //public int Version { get; protected set; }
//    //private bool _isINcremented;
//    //protected void IncrementedVersion()
//    //{
//    //    if (_isINcremented) return;

//    //    _isINcremented = true;
//    //    Version++;
//    //}
//    private List<IDomainEvent> _events = new();
//    public IEnumerable <IDomainEvent> Events => _events;
//    protected void RaiseEventEvent(IDomainEvent domainEvent )
//    {
//        _events.Add(domainEvent);

//        //if(_events.Any() && !_isINcremented)
//        //{
//        //    _isINcremented = true;
//        //    Version++;
//        //}
//    }
//}

