namespace Travelport.AirportRegistration.Application.DTOs;

public class PersonDto
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string PassportNumber { get; set; } = string.Empty;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int AirportId { get; set; }
}

