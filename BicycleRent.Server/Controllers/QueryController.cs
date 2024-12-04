using BicycleRent.Server.Dto;
using BicycleRent.Server.Services;
using Microsoft.AspNetCore.Mvc;


namespace BicycleRent.Server.Controllers;

/// <summary>
/// Class for Query's controller
/// </summary>
/// <param name="service">Query's service</param>
[Route("api/[controller]")]
[ApiController]
public class QueryController(QueryService service) : ControllerBase
{
    /// <summary>
    /// Get bicycles by type
    /// </summary>
    /// <param name="bicycleTypeId">Type ID of the bicycles</param>
    /// <returns>List of bicycles of a specific type <see cref="BicycleDto"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">No bicycles of the given type found</response>
    [HttpGet("bicycles-by-type/{bicycleTypeId}")]
    public ActionResult<IEnumerable<BicycleWithTypeNameDto>> GetBicyclesByType(int bicycleTypeId)
    {
        var bicyclesByType = service.GetBicyclesByType(bicycleTypeId);
        if (!bicyclesByType.Any())
        {
            return NotFound(new { message = $"No bicycles found for type ID {bicycleTypeId}" });
        }
        return Ok(bicyclesByType);
    }

    /// <summary>
    /// Get available bicycles (not rented)
    /// </summary>
    /// <returns>List of available bicycles <see cref="BicycleDto"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">No available bicycles found</response>
    [HttpGet("available-bicycles")]
    public ActionResult<IEnumerable<BicycleWithTypeNameDto>> GetAvailableBicycles()
    {
        var availableBicycles = service.GetAvailableBicycles();
        if (!availableBicycles.Any())
        {
            return NotFound(new { message = "No available bicycles found" });
        }
        return Ok(availableBicycles);
    }

    /// <summary>
    /// Get the top 5 rented bicycles
    /// </summary>
    /// <returns>List of top 5 bicycles <see cref="BicycleDto"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">No rental data available</response>
    [HttpGet("top-five-bicycles")]
    public ActionResult<IEnumerable<TopBicycleDto>> GetTopFiveBicycles()
    {
        var top5Bicycles = service.GetTopFiveBicycles();
        if (!top5Bicycles.Any())
        {
            return NotFound(new { message = "No rental data available for top bicycles" });
        }
        return Ok(top5Bicycles);
    }

    /// <summary>
    /// Get the top customers by rental activity
    /// </summary>
    /// <returns>List of top customers <see cref="CustomerDto"/></returns>
    /// <response code="200">The request was completed successfully</response>
    /// <response code="404">No rental data available</response>
    [HttpGet("top-customers")]
    public ActionResult<IEnumerable<TopCustomerDto>> GetTopCustomers()
    {
        var topCustomers = service.GetTopCustomers();
        if (!topCustomers.Any())
        {
            return NotFound(new { message = "No rental data available for top customers" });
        }
        return Ok(topCustomers);
    }
}
