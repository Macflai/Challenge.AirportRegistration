using System.ComponentModel.DataAnnotations;

namespace Travelport.AirportRegistration.Application.DTOs;

public class AirportDto
{
    [Required]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "Airport code must be exactly 3 characters.")]
    public string Code { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;
}

