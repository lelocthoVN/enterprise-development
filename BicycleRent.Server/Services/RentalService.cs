using AutoMapper;
using BicycleRent.Domain;
using BicycleRent.Domain.Repositories;
using BicycleRent.Server.Dto;

namespace BicycleRent.Server.Services;

/// <summary>
/// Service class for managing Rental operations
/// </summary>
/// <param name="repository">Repository for Rental</param>
/// <param name="mapper">Automapper instance for mapping between RentalDto and Rental</param>
public class RentalService(RentalRepository repository, IMapper mapper) : IService<RentalDto, int>
{
    /// <summary>
    /// Get all rentals
    /// </summary>
    public IEnumerable<RentalDto> GetAll() => repository.GetAll().Select(mapper.Map<RentalDto>);

    /// <summary>
    /// Get a rental by its ID
    /// </summary>
    /// <param name="id">The ID of the rental</param>
    public RentalDto? GetById(int id) => mapper.Map<RentalDto>(repository.GetById(id));

    /// <summary>
    /// Delete a rental by its ID
    /// </summary>
    /// <param name="id">The ID of the rental</param>
    public bool Delete(int id) => repository.Delete(id);

    /// <summary>
    /// Update a rental's information
    /// </summary>
    /// <param name="dtoData">The RentalDto with updated information</param>
    /// <param name="id">The id of the RentalDto to update</param>
    public bool Update(RentalDto dtoData, int id) => repository.Update(mapper.Map<Rental>(dtoData),id);

    /// <summary>
    /// Add a new rental
    /// </summary>
    /// <param name="dtoData">The RentalDto to add</param>
    public void Add(RentalDto dtoData) => repository.Add(mapper.Map<Rental>(dtoData));
}
