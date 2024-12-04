using AutoMapper;
using BicycleRent.Domain.Repositories;
using BicycleRent.Server.Dto;

namespace BicycleRent.Server.Services;

/// <summary>
/// Service class for handling queries related to bicycle rentals
/// </summary>
/// <param name="repository">Query's repository</param>
/// <param name="mapper">Mapper</param>
public class QueryService(QueryRepository repository, IMapper mapper)
{
    /// <summary>
    /// Gets the top 5 bicycles based on their rental activity
    /// </summary>
    /// <returns>List of bicycles with rental counts</returns>
    public IEnumerable<TopBicycleDto> GetTopFiveBicycles()
    {
        return from data in repository.GetTopFiveBicycles()
               select new TopBicycleDto
               {
                   BicycleSerialNumber = data.BicycleSerialNumber,
                   Model = data.Model,
                   TypeName = data.TypeName,
                   RentalCount = data.RentalCount
               };
    }

    /// <summary>
    /// Gets the top customers based on their rental activity
    /// </summary>
    /// <returns>List of customers with rental counts</returns>
    public IEnumerable<TopCustomerDto> GetTopCustomers()
    {
        return from data in repository.GetTopCustomers()
               select new TopCustomerDto
               {
                   CustomerId = data.CustomerId,
                   FullName = data.FullName,
                   RentalCount = data.RentalCount
               };
    }

    /// <summary>
    /// Get list of bicycles that have not been rented yet
    /// </summary>
    /// <returns>List of bicycles that have not been rented</returns>
    public IEnumerable<BicycleWithTypeNameDto> GetAvailableBicycles() => mapper.Map<List<BicycleWithTypeNameDto>>(repository.GetAvailableBicycles());

    /// <summary>
    /// Get a list of bicycles of a certain type
    /// </summary>
    /// <param name="bicycleTypeId">ID of the bicycle type</param>
    /// <returns>List of bicycles of a certain type</returns>
    public IEnumerable<BicycleWithTypeNameDto> GetBicyclesByType(int bicycleTypeId) => mapper.Map<List<BicycleWithTypeNameDto>>(repository.GetBicyclesByType(bicycleTypeId));
}


