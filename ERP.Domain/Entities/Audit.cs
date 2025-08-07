using ERP.Domain.Common;
using ERP.Domain.Entities.User;
using ERP.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Entities;

public class Audit
{
    public int Id { get; set; }
    public int UserId { get; set; }
    //public ApplicationUser User { get; set; }
    public ActionTypeAuditLog ActionType { get; set; } = ActionTypeAuditLog.NONE;
    public string EntityName { get; set; }
    public DateTime Timestamp { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
}
/*
 public class Audit
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public ApplicationUser User { get; set; }

    public ActionTypeAuditLog ActionType { get; set; } = ActionTypeAuditLog.NONE;
    public string EntityName { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public string? CommandName { get; set; } // اضافه شده برای مشخص کردن کامند
    public string? CorrelationId { get; set; } // برای tracing
}

 
 */