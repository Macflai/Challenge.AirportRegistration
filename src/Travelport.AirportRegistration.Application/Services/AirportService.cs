using Travelport.AirportRegistration.Domain.Entities;
using Travelport.AirportRegistration.Application.Interfaces;

namespace Travelport.AirportRegistration.Application.Services;

public class AirportService : IAirportService
{
    private readonly IAirportRepository _airportRepository;

    public AirportService(IAirportRepository airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public async Task<IEnumerable<Airport>> GetAsync() => await _airportRepository.GetAllAsync();
    public async Task<Airport?> GetAsync(int id) => await _airportRepository.GetByIdAsync(id);
    public async Task<Airport?> GetAsync(string code) => await _airportRepository.GetByCodeAsync(code);
    public async Task CreateAsync(Airport airport) => await _airportRepository.AddAsync(airport);
    public async Task UpdateAsync(Airport airport) => await _airportRepository.UpdateAsync(airport);
    public async Task DeleteAsync(int id) => await _airportRepository.DeleteAsync(id);
}