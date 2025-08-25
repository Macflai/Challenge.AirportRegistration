using FluentAssertions;
using Travelport.AirportRegistration.Infrastructure.Repositories;
using Travelport.AirportRegistration.Domain.Entities;
using Travelport.AirportRegistration.UnitTests.Helpers;

namespace Travelport.AirportRegistration.UnitTests.Repositories;

public class AirportRepositoryTests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllAirports()
    {
        //Arrange
        var appDbContext = TestDbContextFactory.CreateInMemoryDbContext($"DbTest-{Guid.NewGuid()}");
        var airportRepository = new AirportRepository(appDbContext);

        //Act
        var airports = await airportRepository.GetAllAsync();

        //Assert
        airports.Count().Should().Be(2);
        airports.First().Id.Should().Be(1);
        airports.First().Code.Should().Be("MAD");
        airports.First().Name.Should().Be("Adolfo Suárez Madrid–Barajas Airport");
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCorrectAirport()
    {
        //Arrange
        var appDbContext = TestDbContextFactory.CreateInMemoryDbContext($"DbTest-{Guid.NewGuid()}");
        var airportRepository = new AirportRepository(appDbContext);

        var airportId = 2;

        //Act
        var airport = await airportRepository.GetByIdAsync(airportId);

        //Assert
        airport.Should().NotBeNull();
        airport.Id.Should().Be(2);
        airport.Code.Should().Be("BCN");
        airport.Name.Should().Be("Barcelona–El Prat Airport");
    }

    [Fact]
    public async Task GetByCodeAsync_ShouldReturnCorrectAirport()
    {
        //Arrange
        var appDbContext = TestDbContextFactory.CreateInMemoryDbContext($"DbTest-{Guid.NewGuid()}");
        var airportRepository = new AirportRepository(appDbContext);

        var airportCode = "BCN";

        //Act
        var airport = await airportRepository.GetByCodeAsync(airportCode);

        //Assert
        airport.Should().NotBeNull();
        airport.Id.Should().Be(2);
        airport.Code.Should().Be("BCN");
        airport.Name.Should().Be("Barcelona–El Prat Airport");
    }

    [Fact]
    public async Task AddAsync_ShouldAddAirport()
    {
        //Arrange
        var appDbContext = TestDbContextFactory.CreateInMemoryDbContext($"DbTest-{Guid.NewGuid()}");
        var airportRepository = new AirportRepository(appDbContext);

        var airportToAdd = new Airport { Id = 3, Code = "VLC", Name = "Valencia Airport" };

        //Act
        await airportRepository.AddAsync(airportToAdd);

        //Assert
        var dbAirports = appDbContext.Airports;
        dbAirports.Count().Should().Be(3);

        var dbAirportAdded = appDbContext.Airports.FirstOrDefault(a => a.Id == 3);
        dbAirportAdded.Should().NotBeNull();
        dbAirportAdded.Id.Should().Be(3);
        dbAirportAdded.Code.Should().Be("VLC");
        dbAirportAdded.Name.Should().Be("Valencia Airport");
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateAirport()
    {
        //Arrange
        var appDbContext = TestDbContextFactory.CreateInMemoryDbContext($"DbTest-{Guid.NewGuid()}");
        var airportRepository = new AirportRepository(appDbContext);

        var airportToUpdate = await airportRepository.GetByIdAsync(2);
        airportToUpdate.Name = "Josep Tarradellas Barcelona-El Prat Airport";

        //Act
        await airportRepository.UpdateAsync(airportToUpdate);

        //Assert
        var dbAirportUpdated = await appDbContext.Airports.FindAsync(2);
        dbAirportUpdated.Id.Should().Be(2);
        dbAirportUpdated.Code.Should().Be("BCN");
        dbAirportUpdated.Name.Should().Be("Josep Tarradellas Barcelona-El Prat Airport");        
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveAirport()
    {
        //Arrange
        var appDbContext = TestDbContextFactory.CreateInMemoryDbContext($"DbTest-{Guid.NewGuid()}");
        var airportRepository = new AirportRepository(appDbContext);

        var airportToDeleteId = 1;

        //Act
        await airportRepository.DeleteAsync(airportToDeleteId);

        //Assert
        var dbAirportDeleted = await appDbContext.Airports.FindAsync(1);
        dbAirportDeleted.Should().BeNull();
    }
}