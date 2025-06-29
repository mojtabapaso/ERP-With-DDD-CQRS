using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ERP.Domain.Specifications;

public interface ISpecification<TEntity>
{
    Expression<Func<TEntity, bool>>? Criteria { get; }
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderBy { get; }
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderByDescending { get; }
    int Skip { get; }
    int Take { get; }
    bool IsPaginationEnabled { get; }
}

public abstract class Specification<TEntity> : ISpecification<TEntity>
{
    public virtual Expression<Func<TEntity, bool>>? Criteria { get; protected set; }
    public virtual Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderBy { get; protected set; }
    public virtual Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderByDescending { get; protected set; }
    public virtual int Skip { get; protected set; }
    public virtual int Take { get; protected set; }
    public virtual bool IsPaginationEnabled { get; protected set; } = false;

    protected void EnablePagination(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPaginationEnabled = true;
    }
}
