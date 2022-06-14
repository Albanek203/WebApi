using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;

namespace WebApi.Repository.Interfaces;

public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class {
    protected BaseRepository(IncidentContext context) { this._context = context; }

    protected readonly IncidentContext _context;
    private DbSet<TEntity> _entities;
    protected DbSet<TEntity> Entities => this._entities ??= _context.Set<TEntity>();

    public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync() =>
        await this.Entities.ToListAsync().ConfigureAwait(false);

    public virtual async Task<IReadOnlyCollection<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate) =>
        await this.Entities.Where(predicate).ToListAsync().ConfigureAwait(false);

    public async Task CreateAsync(TEntity entity) {
        await Entities.AddAsync(entity).ConfigureAwait(false);
        await _context.SaveChangesAsync();
    }
}