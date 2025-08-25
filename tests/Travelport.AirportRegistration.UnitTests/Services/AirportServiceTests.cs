using Moq;
using FluentAssertions;
using Travelport.AirportRegistration.Application.Interfaces;
using Travelport.AirportRegistration.Application.Services;
using Travelport.AirportRegistration.Domain.Entities;

namespace Travelport.AirportRegistration.UnitTests.Services;

public class AirportServiceTests
{
    private readonly AirportService _airportService;
    private readonly Mock<IAirportRepository> _airportRepositoryMock = new();

    public AirportServiceTests()
    {
        _airportRepositoryMock = new Mock<IAirportRepository>();
        _airportService = new AirportService(_airportRepositoryMock.Object);
    }

    [Fact]
    public async Task GetAsync_ShouldCallRepository()
    {
        //Arrange
        var airports = new List<Airport>
        {
            new Airport { Id = 1, Code = "MAD", Name = "Adolfo Suárez Madrid–Barajas Airport" },
            new Airport { Id = 2, Code = "BCN", Name = "Barcelona–El Prat Airport" }
        };

        _airportRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(airports);

        //Act
        var result = await _airportService.GetAsync();

        //Assert
        _airportRepositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
        result.Should().HaveCount(2);
        result.First().Code.Should().Be("MAD");
        result.First().Name.Should().Be("Adolfo Suárez Madrid–Barajas Airport");
    }

    [Fact]
    public async Task CreateAsync_ShouldCallRepository()
    {
        // Arrange
        var airport = new Airport { Id = 3, Code = "VLC", Name = "Valencia Airport" };

        // Act
        await _airportService.CreateAsync(airport);

        // Assert
        _airportRepositoryMock.Verify(r => r.AddAsync(airport), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallRepository()
    {
        // Arrange
        var airport = new Airport { Id = 2, Code = "BCN", Name = "Josep Tarradellas Barcelona-El Prat Airport" };

        // Act
        await _airportService.UpdateAsync(airport);

        // Assert
        _airportRepositoryMock.Verify(r => r.UpdateAsync(airport), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallRepository()
    {
        // Arrange
        var airportId = 1;

        // Act
        await _airportService.DeleteAsync(airportId);

        // Assert
        _airportRepositoryMock.Verify(r => r.DeleteAsync(airportId), Times.Once);
    }
}
