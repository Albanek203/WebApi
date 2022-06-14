using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Models.ViewModels;
using WebApi.Services;
using ClassMapper;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class IncidentController : ControllerBase {
    private readonly IncidentService _incidentService;
    private readonly AccountService _accountService;

    public IncidentController(IncidentService incidentService
                            , AccountService accountService) {
        _incidentService = incidentService;
        _accountService = accountService;
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> Get(string name) {
        var incident = (await _incidentService.FindByConditionAsync(x => x.Name.ToString() == name)).FirstOrDefault();
        if (incident == null) return NotFound();
        return Ok(incident);
    }

    [HttpGet]
    public async Task<IReadOnlyCollection<IncidentViewModel>> GetAll() {
        var incidents = await _incidentService.GetAllAsync();
        return incidents.Select(incident => incident.Map<Incident, IncidentViewModel>()).ToList();
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] IncidentViewModel viewModel) {
        var account = (await _accountService.FindByConditionAsync(x => x.Name == viewModel.Name)).FirstOrDefault();
        if (account == null) { return NotFound(); }
        var incident = new Incident {
            Accounts = new List<Account> { account }, Description = viewModel.Description
        };
        await _incidentService.CreateAsync(incident);
        return CreatedAtAction(nameof(Get), new { name = incident.Name }, incident);
    }
}