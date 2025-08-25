using Travelport.AirportRegistration.Domain.Entities;
using Travelport.AirportRegistration.Application.Interfaces;

namespace Travelport.AirportRegistration.Application.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<IEnumerable<Person>> GetAsync() => await _personRepository.GetAllAsync();
    public async Task<Person?> GetAsync(int id) => await _personRepository.GetByIdAsync(id);
    public async Task<Person?> GetAsync(string passportNumber) => await _personRepository.GetByPassportNumberAsync(passportNumber);
    public async Task CreateAsync(Person person) => await _personRepository.AddAsync(person);
    public async Task UpdateAsync(Person person) => await _personRepository.UpdateAsync(person);
    public async Task DeleteAsync(int id) => await _personRepository.DeleteAsync(id);
}