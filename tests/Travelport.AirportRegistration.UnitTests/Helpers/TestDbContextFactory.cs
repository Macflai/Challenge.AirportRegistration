using Microsoft.EntityFrameworkCore;
using Travelport.AirportRegistration.Infrastructure;
using Travelport.AirportRegistration.Domain.Entities;

namespace Travelport.AirportRegistration.UnitTests.Helpers;

public static class TestDbContextFactory
{
    public static AppDbContext CreateInMemoryDbContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        var context = new AppDbContext(options);

        // Seed airports
        context.Airports.AddRange(
            new Airport { Id = 1, Code = "MAD", Name = "Adolfo Suárez Madrid–Barajas Airport" },
            new Airport { Id = 2, Code = "BCN", Name = "Barcelona–El Prat Airport" }
        );

        // Seed people
        context.People.AddRange(
            new Person { Id = 1, Name = "Jane", Surname = "Doe", PassportNumber = "PZ8472466", AirportId = 1 },
            new Person { Id = 2, Name = "John", Surname = "Smith", PassportNumber = "PT0291014", AirportId = 1 }
        );

        context.SaveChanges();

        return context;
    }
}