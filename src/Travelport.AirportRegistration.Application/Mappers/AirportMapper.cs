using Travelport.AirportRegistration.Application.DTOs;
using Travelport.AirportRegistration.Domain.Entities;

namespace Travelport.AirportRegistration.Application.Mappers;

public static class AirportMapper
{
    public static Airport ToEntity(this AirportDto dto)
    {
        return new Airport
        {
            Code = dto.Code,
            Name = dto.Name
        };
    }

    public static AirportResponseDto ToResponseDto(this Airport entity)
    {
        return new AirportResponseDto
        {
            Id = entity.Id,
            Code = entity.Code,
            Name = entity.Name,
            People = entity.People?.Select(p => $"{p.Name} {p.Surname}").ToList() ?? []
        };
    }

    public static void UpdateFromDto(this Airport entity, AirportDto dto)
    {
        entity.Code = dto.Code;
        entity.Name = dto.Name;
    }
}
