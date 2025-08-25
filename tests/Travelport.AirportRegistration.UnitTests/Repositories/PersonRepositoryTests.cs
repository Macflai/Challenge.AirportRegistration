using FluentAssertions;
using Travelport.AirportRegistration.Infrastructure.Repositories;
using Travelport.AirportRegistration.Domain.Entities;
using Travelport.AirportRegistration.UnitTests.Helpers;

namespace Travelport.AirportRegistration.UnitTests.Repositories;

public class PersonRepositoryTests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllPeople()
    {
        //Arrange
        var appDbContext = TestDbContextFactory.CreateInMemoryDbContext($"DbTest-{Guid.NewGuid()}");
        var personRepository = new PersonRepository(appDbContext);

        //Act
        var people = await personRepository.GetAllAsync();

        //Assert
        people.Count().Should().Be(2);
        people.First().Id.Should().Be(1);
        people.First().Name.Should().Be("Jane");
        people.First().Surname.Should().Be("Doe");
        people.First().PassportNumber.Should().Be("PZ8472466");
        people.First().AirportId.Should().Be(1);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCorrectPerson()
    {
        //Arrange
        var appDbContext = TestDbContextFactory.CreateInMemoryDbContext($"DbTest-{Guid.NewGuid()}");
        var personRepository = new PersonRepository(appDbContext);

        var personId = 2;

        //Act
        var person = await personRepository.GetByIdAsync(personId);

        //Assert
        person.Should().NotBeNull();
        person.Id.Should().Be(2);
        person.Name.Should().Be("John");
        person.Surname.Should().Be("Smith");
        person.PassportNumber.Should().Be("PT0291014");
        person.AirportId.Should().Be(1);
    }

    [Fact]
    public async Task GetByPassportNumberAsync_ShouldReturnCorrectPerson()
    {
        //Arrange
        var appDbContext = TestDbContextFactory.CreateInMemoryDbContext($"DbTest-{Guid.NewGuid()}");
        var personRepository = new PersonRepository(appDbContext);

        var personPassport = "PT0291014";

        //Act
        var person = await personRepository.GetByPassportNumberAsync(personPassport);

        //Assert
        person.Should().NotBeNull();
        person.Id.Should().Be(2);
        person.Name.Should().Be("John");
        person.Surname.Should().Be("Smith");
        person.PassportNumber.Should().Be("PT0291014");
        person.AirportId.Should().Be(1);
    }

    [Fact]
    public async Task AddAsync_ShouldAddPerson()
    {
        //Arrange
        var appDbContext = TestDbContextFactory.CreateInMemoryDbContext($"DbTest-{Guid.NewGuid()}");
        var personRepository = new PersonRepository(appDbContext);

        var personToAdd = new Person { Id = 3, Name = "Johnny", Surname = "B. Goode", PassportNumber = "PG123456", AirportId = 1 };

        //Act
        await personRepository.AddAsync(personToAdd);

        //Assert
        var dbPeople = appDbContext.People;
        dbPeople.Count().Should().Be(3);

        var dbPersonAdded = appDbContext.People.FirstOrDefault(a => a.Id == 3);
        dbPersonAdded.Should().NotBeNull();
        dbPersonAdded.Id.Should().Be(3);
        dbPersonAdded.Name.Should().Be("Johnny");
        dbPersonAdded.Surname.Should().Be("B. Goode");
        dbPersonAdded.PassportNumber.Should().Be("PG123456");
        dbPersonAdded.AirportId.Should().Be(1);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdatePerson()
    {
        //Arrange
        var appDbContext = TestDbContextFactory.CreateInMemoryDbContext($"DbTest-{Guid.NewGuid()}");
        var personRepository = new PersonRepository(appDbContext);

        var personToUpdate = await personRepository.GetByIdAsync(1);
        personToUpdate.Name = "Mary Jane";
        personToUpdate.Email = "maryjane@airportregistration.test";

        //Act
        await personRepository.UpdateAsync(personToUpdate);

        //Assert
        var dbPersonUpdated = await appDbContext.People.FindAsync(1);
        dbPersonUpdated.Id.Should().Be(1);
        dbPersonUpdated.Name.Should().Be("Mary Jane");
        dbPersonUpdated.Surname.Should().Be("Doe");
        dbPersonUpdated.PassportNumber.Should().Be("PZ8472466");
        dbPersonUpdated.Email.Should().Be("maryjane@airportregistration.test");
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemovePerson()
    {
        //Arrange
        var appDbContext = TestDbContextFactory.CreateInMemoryDbContext($"DbTest-{Guid.NewGuid()}");
        var personRepository = new PersonRepository(appDbContext);

        var personToDeleteId = 1;

        //Act
        await personRepository.DeleteAsync(personToDeleteId);

        //Assert
        var dbPersonDeleted = await appDbContext.People.FindAsync(1);
        dbPersonDeleted.Should().BeNull();
    }
}