using Travelport.AirportRegistration.Domain.Entities;

namespace Travelport.AirportRegistration.Application.Interfaces;

public interface IPersonService
{
    Task<IEnumerable<Person>> GetAsync();
    Task<Person?> GetAsync(int id);
    Task<Person?> GetAsync(string passportNumber);
    Task CreateAsync(Person person);
    Task UpdateAsync(Person person);
    Task DeleteAsync(int id);
}