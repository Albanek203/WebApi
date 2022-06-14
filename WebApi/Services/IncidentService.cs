using System.Linq.Expressions;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Services;

public class IncidentService {
    private readonly IncidentRepository _incidentRepository;
    public IncidentService(IncidentRepository incidentRepository) { _incidentRepository = incidentRepository; }

    public async Task CreateAsync(Incident incident) { await _incidentRepository.CreateAsync(incident); }
    public async Task<IReadOnlyCollection<Incident>> GetAllAsync() => await _incidentRepository.GetAllAsync();

    public async Task<IReadOnlyCollection<Incident>> FindByConditionAsync(Expression<Func<Incident, bool>> predicate) =>
        await _incidentRepository.FindByConditionAsync(predicate);
}