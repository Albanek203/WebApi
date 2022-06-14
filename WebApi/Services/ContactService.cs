using System.Linq.Expressions;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Services;

public class ContactService {
    private readonly ContactRepository _contactRepository;
    public ContactService(ContactRepository contactRepository) { _contactRepository = contactRepository; }

    public async Task CreateAsync(Contact contact) { await _contactRepository.CreateAsync(contact); }
    public async Task<IReadOnlyCollection<Contact>> GetAllAsync() => await _contactRepository.GetAllAsync();

    public async Task<IReadOnlyCollection<Contact>> FindByConditionAsync(Expression<Func<Contact, bool>> predicate) =>
        await _contactRepository.FindByConditionAsync(predicate);
}