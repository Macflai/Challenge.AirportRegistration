namespace Travelport.AirportRegistration.Domain.Entities;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string PassportNumber { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public int AirportId { get; set; }
    public Airport? Airport { get; set; }
}
