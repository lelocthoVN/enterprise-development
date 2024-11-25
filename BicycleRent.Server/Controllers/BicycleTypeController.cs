using BicycleRent.Domain;
using BicycleRent.Server.Dto;
using BicycleRent.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRent.Server.Controllers;

/// <summary>
/// Controller for managing operations to bicycle types
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BicycleTypeController(BicycleTypeService service) : ControllerBase
{
    /// <summary>
    /// Get all object
    /// </summary>
    /// <returns>List of objects <see cref="BicycleTypeDto"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Empty list</response>
    [HttpGet]
    public ActionResult<IEnumerable<BicycleTypeDto>> Get()
    {
        var bicycleTypes = service.GetAll();
        if (!bicycleTypes.Any())
        {
            return NotFound("No bicycle types found");
        }
        return Ok(bicycleTypes);
    }

    /// <summary>
    /// Get a object by its ID
    /// </summary>
    /// <param name="id">Object's ID</param>
    /// <returns>A object by ID<see cref="BicycleType"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Object not found</response>
    [HttpGet("{id}")]
    public ActionResult<BicycleTypeDto> Get(int id)
    {
        var bicycleType = service.GetById(id);
        if (bicycleType == null)
        {
            return NotFound($"Bicycle type with ID '{id}' not found");
        }
        return Ok(bicycleType);
    }

    /// <summary>
    /// Add a new object
    /// </summary>
    /// <param name="value">Object to add</param>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Bad request due to invalid input</response>
    [HttpPost]
    public ActionResult<BicycleTypeDto> Post([FromBody] BicycleTypeDto value)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (service.GetById(value.Id) != null)
        {
            return Conflict($"Bicycle type with ID '{value.Id}' already exists");
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
    public ActionResult<BicycleTypeDto> Put([FromBody] BicycleTypeDto value, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); 
        }
        var updated = service.Update(value, id);
        if (!updated)
        {
            return NotFound($"Bicycle type with ID '{id}' not found.");
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
    public ActionResult<BicycleTypeDto> Delete(int id)
    {
        if (!service.Delete(id))
        {
            return NotFound($"Bicycle type with ID '{id}' not found");
        }
        return Ok($"Bicycle type with ID '{id}' deleted successfully");
    }
}
