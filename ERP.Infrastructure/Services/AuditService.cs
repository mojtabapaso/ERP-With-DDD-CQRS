using ERP.Application.Interfaces;
using ERP.Domain.Entities;
using ERP.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace ERP.Infrastructure.Services;

public class AuditService : IAuditService
{
    private readonly HashSet<string> _excludedProperties;

    public AuditService(IEnumerable<string>? excludedProperties = null)
    {
        _excludedProperties = excludedProperties != null
            ? new HashSet<string>(excludedProperties)
            : new HashSet<string>
            {
                "Password",
                "SecurityStamp",
                "ConcurrencyStamp",
                "RefreshToken",
                "RefreshTokenExpiryTime"
            };
    }

    public List<AuditEntry> PrepareAuditEntries(ChangeTracker changeTracker, int userId)
    {
        changeTracker.DetectChanges();
        var auditEntries = new List<AuditEntry>();

        foreach (var entry in changeTracker.Entries())
        {
            if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                continue;

            var auditEntry = new AuditEntry
            {
                UserId = userId,
                EntityName = entry.Entity.GetType().Name,
                ActionType = entry.State switch
                {
                    EntityState.Added => ActionType.INSERT,
                    EntityState.Modified => ActionType.UPDATE,
                    EntityState.Deleted => ActionType.DELETE,
                    _ => throw new NotSupportedException()
                }
            };

            foreach (var prop in entry.Properties)
            {
                var propName = prop.Metadata.Name;

                if (prop.IsTemporary)
                    continue;

                if (_excludedProperties.Contains(propName))
                    continue;

                switch (entry.State)
                {
                    case EntityState.Added:
                        auditEntry.NewValues[propName] = prop.CurrentValue;
                        break;
                    case EntityState.Deleted:
                        auditEntry.OldValues[propName] = prop.OriginalValue;
                        break;
                    case EntityState.Modified:
                        if (prop.IsModified)
                        {
                            auditEntry.OldValues[propName] = prop.OriginalValue;
                            auditEntry.NewValues[propName] = prop.CurrentValue;
                        }
                        break;
                }
            }

            auditEntries.Add(auditEntry);
        }

        return auditEntries;
    }

    public async Task SaveAuditLogsAsync(DbContext context, List<AuditEntry> auditEntries)
    {
        if (!auditEntries.Any()) return;

        var auditLogs = auditEntries.Select(a => new Audit
        {
            UserId = a.UserId,
            EntityName = a.EntityName,
            ActionType = a.ActionType,
            OldValues = a.OldValues.Any() ? JsonSerializer.Serialize(a.OldValues) : null,
            NewValues = a.NewValues.Any() ? JsonSerializer.Serialize(a.NewValues) : null,
        }).ToList();

        context.Set<Audit>().AddRange(auditLogs);
        await context.SaveChangesAsync();
    }
}
