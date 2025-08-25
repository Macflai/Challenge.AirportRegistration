using Travelport.AirportRegistration.Domain.Entities;

namespace Travelport.AirportRegistration.Infrastructure.Repositories.Interfaces;

public interface IAirportRepository : IRepository<Airport>
{
    Task<Airport?> GetByCodeAsync(string code);
}