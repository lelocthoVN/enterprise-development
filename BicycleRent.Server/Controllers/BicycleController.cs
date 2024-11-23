using AutoMapper;
using BicycleRent.Domain;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Server.Dto;
using BicycleRent.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRent.Server.Controllers;

/// <summary>
/// Controller to manage the operation of the bicycles
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BicycleController(BicycleService service) : ControllerBase
{

    /// <summary>
    /// Get all object
    /// </summary>
    /// <returns>List of objects <see cref="BicycleDto"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Empty list</response>
    [HttpGet]
    public ActionResult<IEnumerable<BicycleDto>> Get()
    {
        var bicycles = service.GetAll();
        if (!bicycles.Any())
        {
            return NotFound("No bicycles found");
        }
        return Ok(bicycles);
    }

    /// <summary>
    /// Get a object by its serial number
    /// </summary>
    /// <param name="serialNumber">Object's serial_number</param>
    /// <returns>A object by serial number<see cref="Bicycle"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Object not found</response>
    [HttpGet("{serialNumber}")]
    public ActionResult<BicycleDto> Get(string serialNumber)
    {
        var bicycle = service.GetById(serialNumber);
        if (bicycle == null)
        {
            return NotFound($"Bicycle with serial number '{serialNumber}' not found");
        }
        return Ok(bicycle);
    }
    /// <summary>
    /// Add a new object
    /// </summary>
    /// <param name="value">Object to add</param>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Invalid data provided in the request</response>
    [HttpPost]
    public ActionResult<BicycleDto> Post([FromBody] BicycleDto value)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (service.GetById(value.SerialNumber) != null)
        {
            return Conflict($"Bicycle with serial number '{value.SerialNumber}' already exists");
        }
        service.Add(value);
        return CreatedAtAction(nameof(Get), new { serialNumber = value.SerialNumber }, value);
    }

    /// <summary>
    /// Update a object by its serial number
    /// </summary>
    /// <param name="value">Object to changed</param>
    /// <param name="serialNumber">Object's serial_number</param>
    /// <returns>Object has changed</returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Object not found</response>
    [HttpPut("{serialNumber}")]
    public ActionResult<BicycleDto> Put([FromBody] BicycleDto value, string serialNumber)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (!string.Equals(serialNumber, value.SerialNumber, StringComparison.OrdinalIgnoreCase))
        {
            return BadRequest("The serial number in the URL does not match the serial number in the request body");
        }
        if (!service.Update(value, serialNumber))
        {
            return NotFound($"Bicycle with serial number '{serialNumber}' not found");
        }
        return Ok(value);
    }

    /// <summary>
    /// Delete a object by its serial number
    /// </summary>
    /// <param name="serialNumber">Object's serial_number</param>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Object not found</response>
    [HttpDelete("{serialNumber}")]
    public ActionResult<string> Delete(string serialNumber)
    {
        if (!service.Delete(serialNumber))
        {
            return NotFound($"Bicycle with serial number '{serialNumber}' not found.");
        }
        return Ok($"Bicycle with serial number '{serialNumber}' deleted successfully.");
    }
}

