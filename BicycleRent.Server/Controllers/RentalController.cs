using AutoMapper;
using BicycleRent.Domain;
using BicycleRent.Server.Dto;
using BicycleRent.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRent.Server.Controllers;

/// <summary>
/// Controller for managing operations to rentals
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RentalController(RentalService service) : ControllerBase
{
    /// <summary>
    /// Get all object
    /// </summary>
    /// <returns>List of objects <see cref="RentalDto"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Empty list</response>
    [HttpGet]
    public ActionResult<IEnumerable<RentalDto>> Get()
    {
        var rentals = service.GetAll();
        if (!rentals.Any())
        {
            return NotFound("No rentals found.");
        }
        return Ok(rentals);
    }

    /// <summary>
    /// Get a object by its ID
    /// </summary>
    /// <param name="id">Object's ID</param>
    /// <returns>A object by ID<see cref="Rental"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Object not found</response>
    [HttpGet("{id}")]
    public ActionResult<RentalDto> Get(int id)
    {
        var rental = service.GetById(id);
        if (rental == null)
        {
            return NotFound($"Rental with ID '{id}' not found.");
        }
        return Ok(rental);
    }

    /// <summary>
    /// Add a new object
    /// </summary>
    /// <param name="value">Object to add</param>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Invalid data</response>
    [HttpPost]
    public ActionResult<RentalDto> Post([FromBody] RentalDto value)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        service.Add(value);
        return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
    }

    /// <summary>
    /// Update a object by ID
    /// </summary>
    /// <param name="value">Object to changed</param>
    /// <param name="id">Object's ID</param>
    /// <returns>Object has changed</returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Object not found</response>
    [HttpPut("{id}")]
    public ActionResult<RentalDto> Put([FromBody] RentalDto value, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (!service.Update(value, id))
        {
            return NotFound($"Rental with ID '{value.Id}' not found.");
        }
        return Ok(value);
    }

    /// <summary>
    /// Delete a object by ID
    /// </summary>
    /// <param name="id">Object's ID</param>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Object not found</response>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!service.Delete(id))
        {
            return NotFound($"Rental with ID '{id}' not found.");
        }
        return Ok($"Rental with ID '{id}' deleted successfully.");
    }
}
