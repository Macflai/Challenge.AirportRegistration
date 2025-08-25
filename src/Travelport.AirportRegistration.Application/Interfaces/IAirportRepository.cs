using Travelport.AirportRegistration.Domain.Entities;

namespace Travelport.AirportRegistration.Application.Interfaces;

public interface IAirportRepository : IRepository<Airport>
{
    Task<Airport?> GetByCodeAsync(string code);
}