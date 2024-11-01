using AutoMapper;
using BicycleRent.Domain;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Server.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRent.Server.Controllers;

/// <summary>
/// Controller to manage the operation of the bicycles
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BicycleController(IRepository<Bicycle, string> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Get all object
    /// </summary>
    /// <returns>List of objects <see cref="BicycleDto"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Empty list</response>
    [HttpGet]
    public ActionResult<IEnumerable<Bicycle>>  Get() => Ok(repository.GetAll());

    /// <summary>
    /// Get a object by its serial number
    /// </summary>
    /// <param name="serialNumber">Object's serial_number</param>
    /// <returns>A object by serial number<see cref="Bicycle"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Object not found</response>
    [HttpGet("{serialNumber}")]
    public ActionResult<Bicycle> Get(string serialNumber) => Ok(repository.GetById(serialNumber));

    /// <summary>
    /// Add a new object
    /// </summary>
    /// <param name="value">Object to add</param>
    /// <response code="200">The request was completed successfully</response>
    [HttpPost]
    public IActionResult Post([FromBody] BicycleDto value)
    {
        var bike = mapper.Map<Bicycle>(value);
        repository.Add(bike);
        return Ok();
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
    public ActionResult<Bicycle> Put(string serialNumber, [FromBody] BicycleDto value)
    {
        var bicycle = mapper.Map<Bicycle>(value);
        if (!repository.Update(bicycle, serialNumber))
        {
            NotFound();
        }
        return Ok(bicycle);
    }

    /// <summary>
    /// Delete a object by its serial number
    /// </summary>
    /// <param name="serialNumber">Object's serial_number</param>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Object not found</response>
    [HttpDelete("{serialNumber}")]
    public IActionResult Delete(string serialNumber)
    {
        if (!repository.Delete(serialNumber))
        {
            return NotFound();
        }
        return Ok();
    }
}

