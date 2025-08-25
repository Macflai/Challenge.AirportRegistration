namespace Travelport.AirportRegistration.Domain.Entities;

public class Airport
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public ICollection<Person> People { get; set; } = new List<Person>();
}
