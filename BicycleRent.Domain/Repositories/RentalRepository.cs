using BicycleRent.Domain.Contexts;
using BicycleRent.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BicycleRent.Domain.Repositories;

public class RentalRepository(BicycleRentContext context) : IRepository<Rental, int>
{
    /// <summary>
    /// Get all rentals
    /// </summary>
    public IEnumerable<Rental> GetAll() =>
        context.Rentals
               .Include(r => r.Customer)
               .Include(r => r.Bicycle)
               .ToList();


    /// <summary>
    /// Get a rental by its ID
    /// </summary>
    /// <param name="id">The ID of the rental</param>
    public Rental? GetById(int id) =>
        context.Rentals
               .Include(r => r.Customer)
               .Include(r => r.Bicycle)
               .FirstOrDefault(r => r.Id == id);

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
        context.Rentals.Remove(rental);
        context.SaveChanges();
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
        existingRental.Id = entity.Id;
        existingRental.CustomerId = entity.CustomerId;
        existingRental.BicycleSerialNumber = entity.BicycleSerialNumber;
        existingRental.Begin = entity.Begin;
        existingRental.End = entity.End;
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Add a new rental
    /// </summary>
    /// <param name="entity">The rental to add</param>
    public void Add(Rental entity)
    {
        context.Rentals.Add(entity);
        context.SaveChanges();
    }
}
