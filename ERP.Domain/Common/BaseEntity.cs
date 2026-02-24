using ERP.Domain.AggregateRoots;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Common;

public abstract class BaseEntity 
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
        _id = id;
    }
    protected int _id;
    protected Guid _rowId;
    protected bool _isDeleted;
    protected DateTime _createdAt;
    protected DateTime? _updatedAt;
    //public BaseId BaseId => _id;
    public int  Id => _id;
    public Guid RowId => _rowId;
    //public RowId RowId => _rowId;
    public bool IsDeleted => _isDeleted;
    public DateTime? CreatedAt => _createdAt;
    public DateTime? UpdatedAt => _updatedAt;

    //Domain Activit
    public void Delete() => _isDeleted = true;
    public void MarkAsUpdated() => this._updatedAt = DateTime.UtcNow;

}
