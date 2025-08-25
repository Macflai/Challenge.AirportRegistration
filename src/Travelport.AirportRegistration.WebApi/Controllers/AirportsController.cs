using Microsoft.AspNetCore.Mvc;
using Travelport.AirportRegistration.Application.DTOs;
using Travelport.AirportRegistration.Application.Interfaces;
using Travelport.AirportRegistration.Application.Mappers;

namespace Travelport.AirportRegistration.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AirportsController : ControllerBase
{
    private readonly IAirportService _airportService;

    public AirportsController(IAirportService airportService)
    {
        _airportService = airportService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AirportResponseDto>>> GetAll()
    {
        var airports = await _airportService.GetAsync();

        return Ok(airports.Select(a => a.ToResponseDto()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AirportResponseDto>> GetById([FromRoute] int id)
    {
        var airport = await _airportService.GetAsync(id);

        if (airport == null)
        {
            return NotFound();
        }

        return Ok(airport.ToResponseDto());
    }

    [HttpGet("code/{code}")]
    public async Task<ActionResult<AirportResponseDto>> GetByCode([FromRoute] string code)
    {
        var airport = await _airportService.GetAsync(code);

        if (airport == null)
        {
            return NotFound();
        }

        return Ok(airport.ToResponseDto());
    }

    [HttpPost]
    public async Task<ActionResult<AirportResponseDto>> Create([FromBody] AirportDto airportDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var airport = airportDto.ToEntity();

        await _airportService.CreateAsync(airport);

        return CreatedAtAction(nameof(GetById), new { id = airport.Id }, airport.ToResponseDto());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] AirportDto airportDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var airport = await _airportService.GetAsync(id);

        if (airport == null)
        {
            return NotFound();
        }

        airport.UpdateFromDto(airportDto);

        await _airportService.UpdateAsync(airport);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var airport = await _airportService.GetAsync(id);

        if (airport == null)
        {
            return NotFound();
        }

        await _airportService.DeleteAsync(id);

        return NoContent();
    }
}