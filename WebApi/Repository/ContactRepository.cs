using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Models;
using WebApi.Repository.Interfaces;

namespace WebApi.Repository;

public class ContactRepository : BaseRepository<Contact> {
    public ContactRepository(IncidentContext context) : base(context) { }
    
    public override async Task<IReadOnlyCollection<Contact>> GetAllAsync() =>
        await this.Entities.Include(x=>x.Account).ToListAsync().ConfigureAwait(false);

    public override async Task<IReadOnlyCollection<Contact>> FindByConditionAsync(Expression<Func<Contact, bool>> predicate) =>
        await this.Entities.Where(predicate).Include(x=>x.Account).ToListAsync().ConfigureAwait(false);
}