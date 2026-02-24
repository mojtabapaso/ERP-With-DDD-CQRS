using ERP.Domain.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Domain.Repository;

[AutoRegister(ServiceLifetime.Scoped)]
public interface IOutboxEventDispatcher
{
    Task Insert<TEntity>(int Id) where TEntity : class;
    Task Update<TEntity>(int Id) where TEntity : class;
    Task Delete<TEntity>(int Id) where TEntity : class;

}
