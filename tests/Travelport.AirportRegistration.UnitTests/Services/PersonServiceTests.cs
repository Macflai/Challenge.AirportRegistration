using Moq;
using Travelport.AirportRegistration.Application.Interfaces;
using Travelport.AirportRegistration.Application.Services;
using Travelport.AirportRegistration.Domain.Entities;
using FluentAssertions;

namespace Travelport.AirportRegistration.UnitTests.Services;

public class PersonServiceTests
{
    private readonly PersonService _personService;
    private readonly Mock<IPersonRepository> _personRepositoryMock = new();

    public PersonServiceTests()
    {
        _personRepositoryMock = new Mock<IPersonRepository>();
        _personService = new PersonService(_personRepositoryMock.Object);
    }

    [Fact]
    public async Task GetAsync_ShouldCallRepository()
    {
        // Arrange
        var people = new List<Person>
        {
            new Person { Id = 1, Name = "Jane", Surname = "Doe" },
            new Person { Id = 2, Name = "John", Surname = "Smith" }
        };

        _personRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(people);

        // Act
        var result = await _personService.GetAsync();

        // Assert
        _personRepositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
        result.Should().HaveCount(2);
        result.First().Name.Should().Be("Jane");
        result.First().Surname.Should().Be("Doe");
    }

    [Fact]
    public async Task CreateAsync_ShouldCallRepository()
    {
        // Arrange
        var person = new Person { Id = 3, Name = "Johnny", Surname = "B. Goode" };

        // Act
        await _personService.CreateAsync(person);

        // Assert
        _personRepositoryMock.Verify(r => r.AddAsync(person), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallRepository()
    {
        // Arrange
        var person = new Person { Id = 1, Name = "Mary Jane", Surname = "Doe" };

        // Act
        await _personService.UpdateAsync(person);

        // Assert
        _personRepositoryMock.Verify(r => r.UpdateAsync(person), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallRepository()
    {
        // Arrange
        var personId = 1;

        // Act
        await _personService.DeleteAsync(personId);

        // Assert
        _personRepositoryMock.Verify(r => r.DeleteAsync(personId), Times.Once);
    }
}
