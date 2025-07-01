namespace ERP.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public Guid RowId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
