using BicycleRent.Domain.Contexts;
using BicycleRent.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BicycleRent.Domain.Repositories;

public class BicycleTypeRepository(BicycleRentContext context) : IRepository<BicycleType, int>
{
    /// <summary>
    /// Get all bicycle types
    /// </summary>
    public IEnumerable<BicycleType> GetAll() => context.BicycleTypes.Include(bt => bt.Bicycles).ToList();
    
    /// <summary>
    /// Get a bicycle type by its ID
    /// </summary>
    /// <param name="id">The ID of the bicycle type</param>
    public BicycleType? GetById(int id) => 
        context.BicycleTypes.Include(bt => bt.Bicycles).FirstOrDefault(x => x.Id == id);
    
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
        context.BicycleTypes.Remove(bicycleType);
        context.SaveChanges();
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
        context.SaveChanges();
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
            context.BicycleTypes.Add(entity);
            context.SaveChanges();
        }      
    }
}
