using BicycleRent.Domain.Interfaces;

namespace BicycleRent.Domain.Repositories;

public class RentalRepository : IRepository<Rental, int>
{
    private static readonly List<Rental> _rentals = new List<Rental>();
    private static int _nextId = 0; 

    /// <summary>
    /// Get all rentals
    /// </summary>
    public IEnumerable<Rental> GetAll() => _rentals;

    /// <summary>
    /// Get a rental by its ID
    /// </summary>
    /// <param name="id">The ID of the rental</param>
    public Rental? GetById(int id) => _rentals.FirstOrDefault(r => r.Id == id);

    /// <summary>
    /// Delete a rental by its ID
    /// </summary>
    /// <param name="id">The ID of the rental</param>
    public bool Delete(int id)
    {
        var rental = GetById(id);
        if (rental == null)
        {
            return false;
        }
        _rentals.Remove(rental);
        return true;
    }

    /// <summary>
    /// Update a rental's information
    /// </summary>
    /// <param name="entity">The rental entity with updated information</param>
    /// <param name="id">The ID of the rental to update</param>
    public bool Update(Rental entity, int id)
    {
        var existingRental = GetById(id);
        if (existingRental == null)
        {
            return false;
        }
        existingRental.Bicycle = entity.Bicycle;
        existingRental.Customer = entity.Customer;
        existingRental.Begin = entity.Begin;
        existingRental.End = entity.End;
        return true;
    }

    /// <summary>
    /// Add a new rental
    /// </summary>
    /// <param name="entity">The rental to add</param>
    public void Add(Rental entity)
    {
        // Assign a new ID and add the rental
        entity.Id = _nextId++;
        _rentals.Add(entity);
    }
}
