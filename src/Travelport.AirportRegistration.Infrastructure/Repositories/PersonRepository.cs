using Microsoft.EntityFrameworkCore;
using Travelport.AirportRegistration.Domain.Entities;
using Travelport.AirportRegistration.Application.Interfaces;

namespace Travelport.AirportRegistration.Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _context;

    public PersonRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Person>> GetAllAsync() =>
        await _context.People.Include(p => p.Airport).ToListAsync();

    public async Task<Person?> GetByIdAsync(int id) =>
        await _context.People.Include(p => p.Airport).FirstOrDefaultAsync(p => p.Id == id);

    public async Task<Person?> GetByPassportNumberAsync(string passportNumber) =>
        await _context.People.Include(p => p.Airport).FirstOrDefaultAsync(p => p.PassportNumber == passportNumber);

    public async Task AddAsync(Person person)
    {
        await _context.People.AddAsync(person);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Person person)
    {
        _context.People.Update(person);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var person = await _context.People.FindAsync(id);

        if (person != null)
        {
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}