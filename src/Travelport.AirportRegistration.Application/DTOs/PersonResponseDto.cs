namespace Travelport.AirportRegistration.Application.DTOs;

public class PersonResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string PassportNumber { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? AirportCode { get; set; }
    public string? AirportName { get; set; }
}

