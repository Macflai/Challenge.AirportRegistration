namespace Travelport.AirportRegistration.Application.DTOs;

public class AirportResponseDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<string> People { get; set; } = [];
}

