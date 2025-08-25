using System.ComponentModel.DataAnnotations;

namespace Travelport.AirportRegistration.Application.DTOs;

public class PersonDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Surname { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^[PL][A-Z]\d{7}$", ErrorMessage = "Passport number must start with P or L, followed by another letter and 7 digits.")]
    public string PassportNumber { get; set; } = string.Empty;

    [EmailAddress]
    public string? Email { get; set; }

    [Phone]
    public string? Phone { get; set; }

    [Required]
    public int AirportId { get; set; }
}

