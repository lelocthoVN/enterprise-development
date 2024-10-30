using BicycleRent.Domain.Interfaces;

namespace BicycleRent.Domain.Repositories;

public class BicycleTypeRepository : IRepository<BicycleType, int>
{
    private static readonly List<BicycleType> _bicycleTypes = [];
    private static int _nextId = 0;
    /// <summary>
    /// Get all bicycle types
    /// </summary>
    public IEnumerable<BicycleType> GetAll() => _bicycleTypes;
    
    /// <summary>
    /// Get a bicycle type by its ID
    /// </summary>
    /// <param name="id">The ID of the bicycle type</param>
    public BicycleType? GetById(int id) => _bicycleTypes.FirstOrDefault(x => x.Id == id);
    
    /// <summary>
    /// Delete a bicycle type by its ID
    /// </summary>
    /// <param name="id">The ID of the bicycle type</param>
    public bool Delete(int id)
    {
        var bicycleType = GetById(id);
        if (bicycleType == null)
        {
            return false;
        }
        _bicycleTypes.Remove(bicycleType);
        return true;
    }

    /// <summary>
    /// Update a bicycle type's information
    /// </summary>
    /// <param name="entity">The bicycle type entity with updated information</param>
    /// <param name="id">The ID of the bicycle type to update</param>
    public bool Update(BicycleType entity, int id)
    {
        var existingBicycleType = GetById(id);
        if (existingBicycleType == null)
        {
            return false;
        }
        existingBicycleType.TypeName = entity.TypeName;
        existingBicycleType.RentalPrice = entity.RentalPrice;
        return true;
    }

    /// <summary>
    /// Add a new bicycle type
    /// </summary>
    /// <param name="entity">The bicycle type to add</param>
    public void Add(BicycleType entity)
    {
        if (GetById(entity.Id) == null)
        {
            entity.Id = _nextId++;
            _bicycleTypes.Add(entity);
        }      
    }
}
