using AutoMapper;
using BicycleRent.Domain;
using BicycleRent.Domain.Repositories;
using BicycleRent.Server.Dto;

namespace BicycleRent.Server.Services;

/// <summary>
/// Service class for managing BicycleType operations
/// </summary>
/// <param name="repository">Repository for BicycleType</param>
/// <param name="mapper">Automapper instance for mapping between BicycleTypeDto and BicycleType</param>
public class BicycleTypeService(BicycleTypeRepository repository, IMapper mapper) : IService<BicycleTypeDto, int>
{
    /// <summary>
    /// Get all bicycle types
    /// </summary>
    public IEnumerable<BicycleTypeDto> GetAll() => repository.GetAll().Select(mapper.Map<BicycleTypeDto>);

    /// <summary>
    /// Get a bicycle type by its ID
    /// </summary>
    /// <param name="id">The ID of the bicycle type</param>
    public BicycleTypeDto? GetById(int id) => mapper.Map<BicycleTypeDto>(repository.GetById(id));

    /// <summary>
    ///  Delete a bicycle type by its ID
    /// </summary>
    /// <param name="id">The ID of the bicycle type</param>
    public bool Delete(int id) => repository.Delete(id);

    /// <summary>
    /// Update a bicycle type's information
    /// </summary>
    /// <param name="dtoData">The BicycleTypeDto with updated information</param>
    /// <param name="id">The id of the BicycleTypeDto to update</param>
    public bool Update(BicycleTypeDto dtoData, int id) => repository.Update(mapper.Map<BicycleType>(dtoData), id);
    
    /// <summary>
    /// Add a new bicycle type
    /// </summary>
    /// <param name="dtoData">The BicycleTypeDto to add</param>
    public void Add(BicycleTypeDto dtoData) => repository.Add(mapper.Map<BicycleType>(dtoData));
}
