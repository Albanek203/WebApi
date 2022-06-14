using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Models;
using WebApi.Repository.Interfaces;

namespace WebApi.Repository;

public class IncidentRepository : BaseRepository<Incident> {
    public IncidentRepository(IncidentContext context) : base(context) { }

    public override async Task<IReadOnlyCollection<Incident>> GetAllAsync() =>
        await this.Entities.Include(x => x.Accounts).ThenInclude(x => x.Contacts).ToListAsync().ConfigureAwait(false);

    public override async Task<IReadOnlyCollection<Incident>> FindByConditionAsync(Expression<Func<Incident, bool>> predicate) =>
        await this.Entities.Where(predicate).Include(x => x.Accounts).ThenInclude(x => x.Contacts).ToListAsync()
                  .ConfigureAwait(false);
}