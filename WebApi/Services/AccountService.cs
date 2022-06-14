using System.Linq.Expressions;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Services;

public class AccountService {
    private readonly AccountRepository _accountRepository;
    public AccountService(AccountRepository accountRepository) { _accountRepository = accountRepository; }

    public async Task CreateAsync(Account account) { await _accountRepository.CreateAsync(account); }
    public async Task<IReadOnlyCollection<Account>> GetAllAsync() => await _accountRepository.GetAllAsync();

    public async Task<IReadOnlyCollection<Account>> FindByConditionAsync(Expression<Func<Account, bool>> predicate) =>
        await _accountRepository.FindByConditionAsync(predicate);
}