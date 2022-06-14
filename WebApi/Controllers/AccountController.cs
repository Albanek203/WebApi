using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Models.ViewModels;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : Controller {
    private readonly AccountService _accountService;
    private readonly ContactService _contactService;

    public AccountController(AccountService accountService, ContactService contactService) {
        _accountService = accountService;
        _contactService = contactService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id) {
        var incident = (await _accountService.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();
        if (incident == null) return NotFound();
        return Ok(incident);
    }

    [HttpGet]
    public async Task<IReadOnlyCollection<Account>> GetAll() => await _accountService.GetAllAsync();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AccountViewModel viewModel) {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }
        
        var account = (await _accountService.FindByConditionAsync(x => x.Name == viewModel.Name)).FirstOrDefault();
        if (account != null) { return BadRequest("User with this name already exists"); }
        
        account = new Account { Name = viewModel.Name };
        var contact = (await _contactService.FindByConditionAsync(x => x.Email == viewModel.Email)).FirstOrDefault();
        if (contact == null) {
            contact = new Contact {
                FirstName = viewModel.FirstName, LastName = viewModel.LastName, Email = viewModel.Email
            };
        }
        else {
            contact = new Contact {
                FirstName = viewModel.FirstName, LastName = viewModel.LastName
            };
        }
        account.Contacts = new List<Contact> { contact };
        await _accountService.CreateAsync(account);
        return CreatedAtAction(nameof(Get), new { id = account.Id }, account);
    }
}