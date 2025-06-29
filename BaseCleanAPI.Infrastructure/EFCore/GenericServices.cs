using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ERP.Application.Interface.Entity;
using ERP.Domain.Common;
using ERP.Domain.Specifications;
using ERP.Infrastructure.Context;
using ERP.Infrastructure.UnitOfWork;

namespace ERP.Infrastructure.Services;

public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : BaseEntity, new()
{
    private readonly ERPDBContext _context;
    private readonly DbSet<TEntity> _dbSet;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<GenericService<TEntity>> _logger;

    public GenericService(
        ERPDBContext context,
        IUnitOfWork unitOfWork,
        ILogger<GenericService<TEntity>> logger)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        _logger.LogInformation("Added new entity of type {EntityType}.", typeof(TEntity).Name);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
        _logger.LogInformation("Updated entity of type {EntityType} with ID {Id}.", typeof(TEntity).Name, entity.Id);
    }

    public async Task SoftDeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is null)
        {
            _logger.LogWarning("Entity not found for soft delete. Type: {EntityType}, Id: {Id}", typeof(TEntity).Name, id);
            return;
        }
        entity.IsDeleted = true;
        _dbSet.Update(entity);
        _logger.LogInformation("Soft deleted entity of type {EntityType} with ID {Id}.", typeof(TEntity).Name, id);
    }

    public async Task HardDeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is null)
        {
            _logger.LogWarning("Entity not found for hard delete. Type: {EntityType}, Id: {Id}", typeof(TEntity).Name, id);
            return;
        }
        _dbSet.Remove(entity);
        _logger.LogInformation("Hard deleted entity of type {EntityType} with ID {Id}.", typeof(TEntity).Name, id);
    }

    public async Task<TEntity?> GetByIdAsync(int id, bool includeDeleted = false)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null || (!includeDeleted && entity.IsDeleted)) return null;
        return entity;
    }

    public async Task<List<TEntity>> GetAllAsync(bool includeDeleted = false)
    {
        return await _dbSet.Where(x => includeDeleted || !x.IsDeleted).ToListAsync();
    }

    public async Task<List<TEntity>> GetPaginatedAsync(int offset, int fetch, bool includeDeleted = false)
    {
        return await _dbSet.Where(x => includeDeleted || !x.IsDeleted)
                            .Skip(offset).Take(fetch).ToListAsync();
    }

    public async Task<List<TEntity>> FindAsync(ISpecification<TEntity> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<int> CountAsync(ISpecification<TEntity>? spec = null)
    {
        return spec == null
            ? await _dbSet.CountAsync()
            : await ApplySpecification(spec).CountAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _dbSet.AnyAsync(x => x.Id == id);
    }

    public async Task SaveAsync()
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            await _unitOfWork.SaveChangesAsync();
            await transaction.CommitAsync();
            _logger.LogInformation("Transaction committed for {EntityType}", typeof(TEntity).Name);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Transaction rollback for {EntityType}", typeof(TEntity).Name);
            throw;
        }
    }

    private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
    {
        IQueryable<TEntity> query = _dbSet;

        if (spec.Criteria != null)
            query = query.Where(spec.Criteria);

        if (spec.OrderBy != null)
            query = query.OrderBy(spec.OrderBy);

        if (spec.OrderByDescending != null)
            query = query.OrderByDescending(spec.OrderByDescending);

        if (spec.IsPaginationEnabled)
            query = query.Skip(spec.Skip).Take(spec.Take);

        return query;
    }
}
