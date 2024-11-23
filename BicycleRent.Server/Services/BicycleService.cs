using AutoMapper;
using BicycleRent.Domain;
using BicycleRent.Domain.Repositories;
using BicycleRent.Server.Dto;

namespace BicycleRent.Server.Services;

/// <summary>
/// Service class for managing Bicycle operations
/// </summary>
/// <param name="repository">Bicycle's repository</param>
/// <param name="mapper">Automapper's object for mapping 2 objects BicycleDto and Bicycle</param>
public class BicycleService(BicycleRepository repository, IMapper mapper) : IService<BicycleDto,string>
{
    /// <summary>
    /// Get all bicycles
    /// </summary>
    public IEnumerable<BicycleDto> GetAll() => repository.GetAll().Select(mapper.Map<BicycleDto>);
    
    /// <summary>
    /// Get a bicycle by its serial number
    /// </summary>
    /// <param name="serialNumber">The serial number of the bicycle</param>
    public BicycleDto? GetById(string serialNumber) => mapper.Map<BicycleDto>(repository.GetById(serialNumber));

    /// <summary>
    /// Delete a bicycle by its serial number
    /// </summary>
    /// <param name="serialNumber">The serial number of the bicycle</param>
    public bool Delete(string serialNumber) => repository.Delete(serialNumber);

    /// <summary>
    /// Update a bicycle's information
    /// </summary>
    /// <param name="dtoData">The bicycle with updated information</param>
    /// <param name="serialNumber">The bicycle's serial number with updated information</param>
    public bool Update(BicycleDto dtoData, string serialNumber) => repository.Update(mapper.Map<Bicycle>(dtoData), serialNumber);

    /// <summary>
    /// Add a new bicycle
    /// </summary>
    /// <param name="dtoData">The bicycle to add</param>
    public void Add(BicycleDto dtoData) => repository.Add(mapper.Map<Bicycle>(dtoData));
}
