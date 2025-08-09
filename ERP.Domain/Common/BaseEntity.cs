using ERP.Domain.ValueObjects;
using ERP.Shared.Abstraction.Domain;

namespace ERP.Domain.Common;

public abstract class BaseEntity : AggregateRoot<BaseId>
{
    public BaseEntity()
    {
        
    }
    public BaseEntity(BaseId id)
    {
        _rowId = new RowId(Guid.NewGuid());
        _isDeleted = false;
        _createdAt = DateTime.UtcNow;
        _updatedAt = null;
        Id = id;
    }
    protected BaseId _id;
    protected RowId _rowId;
    protected bool _isDeleted;
    protected DateTime _createdAt;
    protected DateTime? _updatedAt;
    public BaseId BaseId => _id;
    public RowId RowId => _rowId;
    public bool IsDeleted => _isDeleted;
    public DateTime? CreatedAt => _createdAt;
    public DateTime? UpdatedAt => _updatedAt;

}
