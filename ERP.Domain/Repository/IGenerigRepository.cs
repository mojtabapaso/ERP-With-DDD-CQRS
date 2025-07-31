using ERP.Domain.ValueObjects;

namespace ERP.Domain.Repository;

public interface IGenericWriteRepository<TEntity> where TEntity : class
{
    Task<bool> ExistByIdAsync(BaseId id);
    Task<bool> ExistByRowIdAsync(RowId id);
    Task<TEntity> CreateAsync(TEntity entity);
    Task DeleteByIdAsync(BaseId id);
    Task SoftDeleteByIdAsync(BaseId id);
    Task DeleteByRowIdAsync(RowId rowId);
    Task SoftDeleteByRowIdAsync(RowId rowId);
    Task<TEntity> UpdateAsync(TEntity entity);
}
public interface IGenericReadRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByRowIdAsync(RowId rowId);
    Task<TEntity> GetByIdAsync(BaseId id);
}