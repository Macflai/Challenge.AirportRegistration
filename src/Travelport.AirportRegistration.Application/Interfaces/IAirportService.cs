using Travelport.AirportRegistration.Domain.Entities;

namespace Travelport.AirportRegistration.Application.Interfaces;

public interface IAirportService
{
    Task<IEnumerable<Airport>> GetAsync();
    Task<Airport?> GetAsync(int id);
    Task<Airport?> GetAsync(string code);
    Task CreateAsync(Airport airport);
    Task UpdateAsync(Airport airport);
    Task DeleteAsync(int id);
}