using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Models;
using WebApi.Repository.Interfaces;

namespace WebApi.Repository;

public class AccountRepository : BaseRepository<Account> {
    public AccountRepository(IncidentContext context) : base(context) { }

    public override async Task<IReadOnlyCollection<Account>> GetAllAsync() =>
        await this.Entities.Include(x=>x.Incident).Include(x => x.Contacts).ToListAsync().ConfigureAwait(false);

    public override async Task<IReadOnlyCollection<Account>> FindByConditionAsync(Expression<Func<Account, bool>> predicate) =>
        await this.Entities.Where(predicate).Include(x=>x.Incident).Include(x => x.Contacts).ToListAsync().ConfigureAwait(false);
}