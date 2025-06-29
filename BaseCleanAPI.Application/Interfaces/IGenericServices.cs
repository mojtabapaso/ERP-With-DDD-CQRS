using ERP.Domain.Common;
using System.Linq.Expressions;

namespace ERP.Application.Interfaces;

public interface IGenericServices<TEntity> where TEntity : BaseEntity, new()
{
    // Create
    void Add(TEntity entity);
    Task AddAsync(TEntity entity);

    // Update
    void Update(TEntity entity);

    // Soft Delete
    void Remove(TEntity entity);
    void Remove(int id);
    void RemoveByRowId(Guid rowId);

    // Hard Delete
    void HardDelete(int id);
    Task HardDeleteAsync(int id);
    void HardDeleteByRowId(Guid rowId);
    Task HardDeleteByRowIdAsync(Guid rowId);

    // Find (Only Not Deleted)
    TEntity? FindById(int id);
    Task<TEntity?> FindByIdAsync(int id);
    TEntity? FindByRowId(Guid rowId);
    Task<TEntity?> FindByRowIdAsync(Guid rowId);

    // Read All (Only Not Deleted)
    List<TEntity> GetAll(int? count = null);
    Task<List<TEntity>> GetAllAsync(int? count = null);
    List<TEntity> GetAllByPagination(int offset, int fetch);
    Task<List<TEntity>> GetAllByPaginationAsync(int offset, int fetch);

    // Read All (Ignore IsDeleted)
    List<TEntity> ReadAll(int? count = null);
    Task<List<TEntity>> ReadAllAsync(int? count = null);
    List<TEntity> ReadAllByPagination(int offset, int fetch);
    Task<List<TEntity>> ReadAllByPaginationAsync(int offset, int fetch);
    TEntity? ReadById(int id);
    Task<TEntity?> ReadByIdAsync(int id);
    TEntity? ReadByRowId(Guid rowId);
    Task<TEntity?> ReadByRowIdAsync(Guid rowId);

    // Util
    IQueryable<TEntity> AsQueryable();
    Task<int> CountAsync(bool includeDeleted = false);
    Task<bool> ExistsAsync(int id);

    // Save
    void Save();
    Task SaveAsync();
}
