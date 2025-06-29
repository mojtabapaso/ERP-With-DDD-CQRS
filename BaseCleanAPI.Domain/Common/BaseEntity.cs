namespace ERP.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; } 
    public Guid RowId { get; set; } = Guid.NewGuid();
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
