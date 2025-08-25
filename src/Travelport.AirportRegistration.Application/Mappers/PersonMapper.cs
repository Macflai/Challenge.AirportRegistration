using Travelport.AirportRegistration.Application.DTOs;
using Travelport.AirportRegistration.Domain.Entities;

namespace Travelport.AirportRegistration.Application.Mappers;

public static class PersonMapper
{
    public static Person ToEntity(this PersonDto dto)
    {
        return new Person
        {
            Name = dto.Name,
            Surname = dto.Surname,
            PassportNumber = dto.PassportNumber,
            AirportId = dto.AirportId,
            Email = dto.Email,
            Phone = dto.Phone
        };
    }

    public static PersonResponseDto ToResponseDto(this Person entity)
    {
        return new PersonResponseDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
            PassportNumber = entity.PassportNumber,
            Email = entity.Email,
            Phone = entity.Phone,
            AirportCode = entity.Airport?.Code,
            AirportName = entity.Airport?.Name
        };
    }

    public static void UpdateFromDto(this Person entity, PersonDto dto)
    {
        entity.Name = dto.Name;
        entity.Surname = dto.Surname;
        entity.PassportNumber = dto.PassportNumber;
        entity.AirportId = dto.AirportId;
        entity.Email = dto.Email;
        entity.Phone = dto.Phone;
    }
}