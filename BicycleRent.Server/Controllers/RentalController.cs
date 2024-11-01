using AutoMapper;
using BicycleRent.Domain;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Server.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRent.Server.Controllers;

/// <summary>
/// Controller for managing operations to rentals
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RentalController(IRepository<Rental, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Get all object
    /// </summary>
    /// <returns>List of objects <see cref="RentalDto"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Empty list</response>
    [HttpGet]
    public ActionResult<IEnumerable<Rental>> Get() => Ok(repository.GetAll());

    /// <summary>
    /// Get a object by its ID
    /// </summary>
    /// <param name="id">Object's ID</param>
    /// <returns>A object by ID<see cref="Rental"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Object not found</response>
    [HttpGet("{id}")]
    public ActionResult<Customer> Get(int id) => Ok(repository.GetById(id));

    /// <summary>
    /// Add a new object
    /// </summary>
    /// <param name="value">Object to add</param>
    /// <response code="200">The request was completed successfully</response>
    [HttpPost]
    public IActionResult Post([FromBody] RentalDto value)
    {
        var rental = mapper.Map<Rental>(value);
        repository.Add(rental);
        return Ok();
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
    public ActionResult<Rental> Put(int id, [FromBody] RentalDto value)
    {
        var rental = mapper.Map<Rental>(value);
        if (!repository.Update(rental, id))
        {
            NotFound();
        }
        return Ok(rental);
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
        if (!repository.Delete(id))
        {
            return NotFound();
        }
        return Ok();
    }
}
