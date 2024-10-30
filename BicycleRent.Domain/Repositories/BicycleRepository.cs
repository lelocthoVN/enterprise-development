using BicycleRent.Domain.Interfaces;

namespace BicycleRent.Domain.Repositories;

public class BicycleRepository : IRepository<Bicycle, string>
{
    private static readonly List<Bicycle> _bicycles = [];

    /// <summary>
    /// Get all bicycles
    /// </summary>
    public IEnumerable<Bicycle> GetAll() => _bicycles;

    /// <summary>
    /// Get a bicycle by its serial number
    /// </summary>
    /// <param name="serial_number">The serial number of the bicycle</param>
    public Bicycle? GetById(string serial_number) => _bicycles.FirstOrDefault(x => x.SerialNumber == serial_number);

    /// <summary>
    /// Delete a bicycle by its serial number
    /// </summary>
    /// <param name="serial_number">The serial number of the bicycle</param>
    public bool Delete(string serial_number)
    {
        var bicycle = GetById(serial_number);
        if (bicycle == null)
        {
            return false;
        }
        _bicycles.Remove(bicycle);
        return true;
    }

    /// <summary>
    /// Update a bicycle's information
    /// </summary>
    /// <param name="entity">The bicycle entity with updated information</param>
    /// <param name="serial_number">The serial number of the bicycle to update</param>
    public bool Update(Bicycle entity, string serial_number)
    {
        var existingBicycle = GetById(serial_number);
        if (existingBicycle == null)
        {
            return false;
        }
        existingBicycle.TypeId = entity.TypeId;
        existingBicycle.Model = entity.Model;
        existingBicycle.Color = entity.Color;
        return true;
    }

    /// <summary>
    /// Add a new bicycle
    /// </summary>
    /// <param name="entity">The bicycle to add</param>
    public void Add(Bicycle entity)
    {
        if(GetById(entity.SerialNumber) == null)
            _bicycles.Add(entity);
    }
}
