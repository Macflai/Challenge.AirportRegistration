using Microsoft.AspNetCore.Mvc;
using Travelport.AirportRegistration.Application.DTOs;
using Travelport.AirportRegistration.Application.Interfaces;
using Travelport.AirportRegistration.Application.Mappers;

namespace Travelport.AirportRegistration.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly IPersonService _personService;
    private readonly ILogger<PeopleController> _logger;

    public PeopleController(IPersonService personService, ILogger<PeopleController> logger)
    {
        _personService = personService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonResponseDto>>> GetAll()
    {
        var people = await _personService.GetAsync();

        return Ok(people.Select(p => p.ToResponseDto()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonResponseDto>> GetById([FromRoute] int id)
    {
        var person = await _personService.GetAsync(id);

        if (person == null)
        {
            return NotFound();
        }

        return Ok(person.ToResponseDto());
    }

    [HttpGet("passport/{passportNumber}")]
    public async Task<ActionResult<PersonResponseDto>> GetByPassportNumber([FromQuery] string passportNumber)
    {
        var person = await _personService.GetAsync(passportNumber);

        if (person == null)
        {
            return NotFound();
        }

        return Ok(person.ToResponseDto());
    }

    [HttpPost]
    public async Task<ActionResult<PersonResponseDto>> Create([FromBody] PersonDto personDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var person = personDto.ToEntity();

        await _personService.CreateAsync(person);

        _logger.LogInformation($"Person created with Id {person.Id}");

        return CreatedAtAction(nameof(GetById), new { id = person.Id }, person.ToResponseDto());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] PersonDto personDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var person = await _personService.GetAsync(id);

        if (person == null)
        {
            return NotFound();
        }

        person.UpdateFromDto(personDto);

        await _personService.UpdateAsync(person);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var person = await _personService.GetAsync(id);

        if (person == null)
        {
            return NotFound();
        }

        await _personService.DeleteAsync(id);

        return NoContent();
    }
}