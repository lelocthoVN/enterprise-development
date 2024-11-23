using AutoMapper;
using BicycleRent.Domain;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Server.Dto;
using BicycleRent.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRent.Server.Controllers;

/// <summary>
/// Controller to manage the operation of the customers
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CustomerController(CustomerService service) : ControllerBase
{
    /// <summary>
    /// Get all object
    /// </summary>
    /// <returns>List of objects <see cref="CustomerDto"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Empty list</response>
    [HttpGet]
    public ActionResult<IEnumerable<CustomerDto>> Get()
    {
        var customers = service.GetAll();
        if (!customers.Any())
        {
            return NotFound("No customers found");
        }
        return Ok(customers);
    }

    /// <summary>
    /// Get a object by its ID
    /// </summary>
    /// <param name="id">Object's ID</param>
    /// <returns>A object by ID<see cref="Customer"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Object not found</response>
    [HttpGet("{id}")]
    public ActionResult<CustomerDto> Get(int id)
    {
        var customer = service.GetById(id);
        if (customer == null)
        {
            return NotFound($"Customer with ID '{id}' not found");
        }
        return Ok(customer);
    }

    /// <summary>
    /// Add a new object
    /// </summary>
    /// <param name="value">Object to add</param>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">Invalid data</response>
    [HttpPost]
    public ActionResult<CustomerDto> Post([FromBody] CustomerDto value)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (service.GetById(value.Id) != null)
        {
            return Conflict($"Customer with ID '{value.Id}' already exists");
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
    public ActionResult<CustomerDto> Put([FromBody] CustomerDto value, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (!service.Update(value, id))
        {
            return NotFound($"Customer with ID '{id}' not found");
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
    public ActionResult<CustomerDto> Delete(int id)
    {
        if (!service.Delete(id))
        {
            return NotFound($"Customer with ID '{id}' not found");
        }
        return Ok($"Customer with ID '{id}' deleted successfully");
    }
}
