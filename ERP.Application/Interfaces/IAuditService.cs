using ERP.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ERP.Application.Interfaces;
public class AuditEntry
{
    public string EntityName { get; set; }
    public int UserId { get; set; }
    public ActionType ActionType { get; set; }
    public Dictionary<string, object> OldValues { get; } = new();
    public Dictionary<string, object> NewValues { get; } = new();
}
public interface IAuditService
{
    List<AuditEntry> PrepareAuditEntries(ChangeTracker changeTracker, int userId);
    Task SaveAuditLogsAsync(DbContext context, List<AuditEntry> auditEntries);
}