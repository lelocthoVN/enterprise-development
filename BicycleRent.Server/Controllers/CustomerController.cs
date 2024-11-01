using AutoMapper;
using BicycleRent.Domain;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Server.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRent.Server.Controllers;

/// <summary>
/// Controller to manage the operation of the customers
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CustomerController(IRepository<Customer, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Get all object
    /// </summary>
    /// <returns>List of objects <see cref="CustomerDto"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Empty list</response>
    [HttpGet]
    public ActionResult<IEnumerable<Customer>> Get() => Ok(repository.GetAll());

    /// <summary>
    /// Get a object by its ID
    /// </summary>
    /// <param name="id">Object's ID</param>
    /// <returns>A object by ID<see cref="Customer"/></returns>
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
    public IActionResult Post([FromBody] CustomerDto value)
    {
        var customer = mapper.Map<Customer>(value);
        repository.Add(customer);
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
    public ActionResult<Customer> Put(int id, [FromBody] CustomerDto value)
    {
        var customer = mapper.Map<Customer>(value);
        if (!repository.Update(customer, id))
        {
            NotFound();
        }
        return Ok(customer);
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
