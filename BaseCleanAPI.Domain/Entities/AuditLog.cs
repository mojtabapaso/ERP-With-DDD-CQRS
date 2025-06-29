using ERP.Domain.Common;

namespace ERP.Domain.Entities;

public class AuditLog: BaseEntity
{
    public int Id { get; set; }
    public Guid? UserId { get; set; }
    public string ActionType { get; set; } = default!;
    public string EntityName { get; set; } = default!;
    public DateTime Timestamp { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
}
