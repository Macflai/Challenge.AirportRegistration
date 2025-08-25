using Travelport.AirportRegistration.Domain.Entities;

namespace Travelport.AirportRegistration.Infrastructure.Repositories.Interfaces;

public interface IPersonRepository : IRepository<Person>
{
    Task<Person?> GetByPassportNumberAsync(string passportNumber);
}