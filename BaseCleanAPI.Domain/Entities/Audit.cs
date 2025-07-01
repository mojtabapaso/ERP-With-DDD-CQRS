using ERP.Domain.Common;
using ERP.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Entities;

public class Audit
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public ApplicationUser User { get; set; }
    public ActionTypeAuditLog ActionType { get; set; } = ActionTypeAuditLog.NONE;
    public string EntityName { get; set; }
    public DateTime Timestamp { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
}
