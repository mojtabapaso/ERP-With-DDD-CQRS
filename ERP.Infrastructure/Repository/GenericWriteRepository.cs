using ERP.Domain.Common;
using ERP.Domain.Repository;
using ERP.Domain.ValueObjects;
using ERP.Infrastructure.Persistence.Contaxt;
using MassTransit;
using MassTransit.Initializers;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Generic;

public class GenericWriteRepository<TEntity> : IGenericWriteRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly WriteDbContext context;
    private readonly IPublishEndpoint publish;
    protected readonly DbSet<TEntity> dbSet;

    public GenericWriteRepository(WriteDbContext context, IPublishEndpoint publish)
    {
        this.context = context;
        this.publish = publish;
        dbSet = this.context.Set<TEntity>();
    }

    public GenericWriteRepository(WriteDbContext context)
    {
        this.context = context;
        dbSet = this.context.Set<TEntity>();
    }
    public async Task<TEntity> GetByRowIdAsync(RowIdValueObject rowId)
    {
        return await dbSet.FirstOrDefaultAsync(c => c.RowId == rowId.Value);
    }
    public async Task<TEntity> GetByIdAsync(BaseId Id)
    {
        return await dbSet.FirstOrDefaultAsync(x => x.Id == Id.Value);
        //return await _dbSet.FirstOrDefaultAsync(e => EF.Property<BaseId>(e, "Id") == Id); ;
    }
    public async Task<bool> ExistByIdAsync(BaseId id)
    {
        return await dbSet.AnyAsync(e => EF.Property<BaseId>(e, "Id") == id);
    }

    public async Task<bool> ExistByRowIdAsync(RowIdValueObject id)
    {
        return await dbSet.AnyAsync(e => EF.Property<RowIdValueObject>(e, "RowId") == id);
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        //await _context.PublishEntityChangesAsync(publish);
        //_context.AddDomainEvent(new EntityCreatedEvent<TEntity>(entity));
        return entity;
    }

    public async Task DeleteByIdAsync(BaseId id)
    {
        TEntity? entity = await dbSet.FirstOrDefaultAsync(e => EF.Property<BaseId>(e, "Id") == id);
        if (entity != null)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }
    }

    public async Task SoftDeleteByIdAsync(BaseId id)
    {
        TEntity? entity = await dbSet.FirstOrDefaultAsync(e => EF.Property<BaseId>(e, "Id") == id);
        if (entity != null)
        {
            entity.Delete();
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteByRowIdAsync(RowIdValueObject rowId)
    {
        TEntity? entity = await dbSet.FirstOrDefaultAsync(e => EF.Property<RowIdValueObject>(e, "RowId") == rowId);
        if (entity != null)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }
    }

    public async Task SoftDeleteByRowIdAsync(RowIdValueObject rowId)
    {
        TEntity? entity = await dbSet.FirstOrDefaultAsync(e => EF.Property<RowIdValueObject>(e, "RowId") == rowId);
        if (entity != null)
        {
            entity.Delete();
            await context.SaveChangesAsync();
        }
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.MarkAsUpdated();
        dbSet.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<Guid> GetRowIdByIdAsync(BaseId Id)
    {
        Guid rowId = await dbSet
        .Where(x => x.Id == Id.Value)
        .Select(x => x.RowId)
        .FirstOrDefaultAsync();
        return rowId;

    }
}

