using Microsoft.EntityFrameworkCore;
using Travelport.AirportRegistration.Domain.Entities;
using Travelport.AirportRegistration.Application.Interfaces;

namespace Travelport.AirportRegistration.Infrastructure.Repositories;

public class AirportRepository : IAirportRepository
{
    private readonly AppDbContext _context;

    public AirportRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Airport>> GetAllAsync() =>
        await _context.Airports.Include(a => a.People).ToListAsync();

    public async Task<Airport?> GetByIdAsync(int id) =>
        await _context.Airports.Include(a => a.People).FirstOrDefaultAsync(a => a.Id == id);

    public async Task<Airport?> GetByCodeAsync(string code) =>
        await _context.Airports.Include(a => a.People).FirstOrDefaultAsync(a => a.Code == code);

    public async Task AddAsync(Airport airport)
    {
        await _context.Airports.AddAsync(airport);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Airport airport)
    {
        _context.Airports.Update(airport);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var airport = await _context.Airports.FindAsync(id);

        if (airport != null)
        {
            _context.Airports.Remove(airport);
            await _context.SaveChangesAsync();
        }
    }
}