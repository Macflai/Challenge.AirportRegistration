using Travelport.AirportRegistration.Domain.Entities;

namespace Travelport.AirportRegistration.Application.Interfaces;

public interface IPersonRepository : IRepository<Person>
{
    Task<Person?> GetByPassportNumberAsync(string passportNumber);
}