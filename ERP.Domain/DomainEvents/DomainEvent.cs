using ERP.Domain.Common;

namespace ERP.Domain.DomainEvents;


//public abstract class DomainEvent<TEntity> where TEntity : BaseEntity
//{
//    public string EntityName { get; }
//    public DateTime OccurredOn { get; } = DateTime.UtcNow;

//    protected DomainEvent(TEntity entity)
//    {
//        EntityName = entity.GetType().Name;
//    }
//}

//public class EntityCreatedEvent<TEntity> : DomainEvent<TEntity> where TEntity : BaseEntity
//{
//    public EntityCreatedEvent(TEntity entity) : base(entity) { }
//}

//public class EntityUpdatedEvent<TEntity> : DomainEvent<TEntity> where TEntity : BaseEntity
//{
//    public EntityUpdatedEvent(TEntity entity) : base(entity) { }
//}

//public class EntityDeletedEvent<TEntity> : DomainEvent<TEntity> where TEntity : BaseEntity
//{
//    public EntityDeletedEvent(TEntity entity) : base(entity) { }
//}
