using ERP.Domain.Common;
using ERP.Domain.ValueObjects;

namespace ERP.Domain.Repository;

public interface IGenericWriteRepository<TEntity> where TEntity : BaseEntity
{
    Task<bool> ExistByIdAsync(BaseId id);
    Task<bool> ExistByRowIdAsync(RowIdValueObject id);
    Task<TEntity> GetByRowIdAsync(RowIdValueObject rowId);
    Task<Guid> GetRowIdByIdAsync(BaseId Id);
    Task<TEntity> CreateAsync(TEntity entity);
    Task DeleteByIdAsync(BaseId id);
    Task SoftDeleteByIdAsync(BaseId id);
    Task DeleteByRowIdAsync(RowIdValueObject rowId);
    Task SoftDeleteByRowIdAsync(RowIdValueObject rowId);
    Task<TEntity> UpdateAsync(TEntity entity);
}
public interface IGenericReadRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByRowIdAsync(RowIdValueObject rowId);
    Task<TEntity> GetByIdAsync(BaseId id);
}