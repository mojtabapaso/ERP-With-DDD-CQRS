using ERP.Domain.Entities;
using ERP.Domain.Enums;
using ERP.Domain.Repository;
using ERP.Infrastructure.Persistence.Contaxt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ERP.Infrastructure.Repository;

public class OutboxEventDispatcher : IOutboxEventDispatcher
{
    private readonly WriteDbContext _context;
    private readonly DbSet<EntityOutbox> _dbSet;

    public OutboxEventDispatcher(WriteDbContext context)
    {
        _context = context;
        _dbSet = context.Set<EntityOutbox>();
    }

    public Task Insert<TEntity>(int id) where TEntity : class
        => AddToOutbox<TEntity>(id, ActionType.INSERT);

    public Task Update<TEntity>(int id) where TEntity : class
        => AddToOutbox<TEntity>(id, ActionType.UPDATE);

    public Task Delete<TEntity>(int id) where TEntity : class
        => AddToOutbox<TEntity>(id, ActionType.DELETE);

    private async Task AddToOutbox<TEntity>(int entityId, ActionType actionType) where TEntity : class
    {
        var fullName = GetFullTableName<TEntity>(_context);

        await _dbSet.AddAsync(new EntityOutbox
        {
            EntityId = entityId,
            //EntityFullName = fullName,
            ActionType = actionType,
            CreatedDate = DateTime.UtcNow,
            Success = false
        });
    }

    private static string GetFullTableName<TEntity>(DbContext context) where TEntity : class
    {
        var entityType = context.Model.FindEntityType(typeof(TEntity));
        if (entityType == null)
            throw new InvalidOperationException($"Entity type {typeof(TEntity).Name} not found in DbContext.");

        var schema = entityType.GetSchema() ?? "dbo";
        var tableName = entityType.GetTableName();

        return $"{schema}.{tableName}";
    }
}
