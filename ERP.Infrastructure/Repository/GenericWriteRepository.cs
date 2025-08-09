using ERP.Domain.Common;
using ERP.Domain.Repository;
using ERP.Domain.ValueObjects;
using ERP.Infrastructure.Persistence;
using ERP.Infrastructure.Persistence.Contaxt;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Generic;

public class GenericWriteRepository<TEntity> : IGenericWriteRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly WriteDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericWriteRepository(WriteDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    public async Task<TEntity> GetByRowIdAsync(RowId rowId)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.RowId == rowId);
    }
    public async Task<bool> ExistByIdAsync(BaseId id)
    {
        return await _dbSet.AnyAsync(e => EF.Property<BaseId>(e, "Id") == id);
    }

    public async Task<bool> ExistByRowIdAsync(RowId id)
    {
        return await _dbSet.AnyAsync(e => EF.Property<RowId>(e, "RowId") == id);
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteByIdAsync(BaseId id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => EF.Property<BaseId>(e, "Id") == id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SoftDeleteByIdAsync(BaseId id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => EF.Property<BaseId>(e, "Id") == id);
        if (entity != null)
        {
            EF.Property<bool>(entity, "IsDeleted");
            typeof(TEntity).GetProperty("IsDeleted")?.SetValue(entity, true);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteByRowIdAsync(RowId rowId)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => EF.Property<RowId>(e, "RowId") == rowId);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SoftDeleteByRowIdAsync(RowId rowId)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => EF.Property<RowId>(e, "RowId") == rowId);
        if (entity != null)
        {
            typeof(TEntity).GetProperty("IsDeleted")?.SetValue(entity, true);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }



}

