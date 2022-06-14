using System.Linq.Expressions;

namespace WebApi.Repository.Interfaces;

public interface IRepository<TEntity> {
    Task<IReadOnlyCollection<TEntity>> GetAllAsync();
    Task<IReadOnlyCollection<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate);
}