using BicycleRent.Domain.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BicycleRent.Domain.Repositories;

public class QueryRepository(BicycleRentContext context)
{
    /// <summary>
    /// Get top 5 most rented bicycles
    /// </summary>
    /// <returns>Collection of top 5 bicycles with their rental count</returns>
    public List<(string BicycleSerialNumber, string Model, string TypeName, int RentalCount)> GetTopFiveBicycles()
    {
        var queryResult = context.Rentals
            .GroupBy(r => new { r.BicycleSerialNumber, r.Bicycle!.Model, r.Bicycle.TypeId })
            .Select(g => new
            {
                g.Key.BicycleSerialNumber,
                g.Key.Model,
                g.Key.TypeId,
                RentalCount = g.Count()
            })
            .OrderByDescending(r => r.RentalCount)
            .Take(5)
            .ToList();

        return queryResult
            .Select(r =>
            {
                var bicycleType = context.BicycleTypes.FirstOrDefault(bt => bt.Id == r.TypeId);
                return (r.BicycleSerialNumber, r.Model, bicycleType?.TypeName, r.RentalCount);
            })
            .ToList();
    }

    /// <summary>
    /// Get top customers based on their rental activities
    /// </summary>
    /// <returns>Collection of top customers with their rental count</returns>
    public List<(int CustomerId, string FullName, int RentalCount)> GetTopCustomers()
    {
        var queryResult = context.Rentals
            .GroupBy(r => new { r.CustomerId, r.Customer!.FullName }) 
            .Select(g => new
            {
                g.Key.CustomerId,
                g.Key.FullName,
                RentalCount = g.Count()
            })
            .OrderByDescending(c => c.RentalCount) 
            .ToList(); 

        return queryResult
            .Select(r => (r.CustomerId, r.FullName, r.RentalCount))
            .ToList();
    }

    /// <summary>
    /// Get list of bikes that have not been rented yet
    /// </summary>
    /// <returns>List of bikes that have not been rented</returns>
    public List<Bicycle> GetAvailableBicycles()
    {
        var availableBicycles = context.Bicycles
            .Include(b => b.BicycleType)
            .Where(b => !context.Rentals.Any(r => r.BicycleSerialNumber == b.SerialNumber && r.End > DateTime.Now)) 
            .ToList();
        return availableBicycles;
    }

    /// <summary>
    /// Get a list of bicycles of a certain type
    /// </summary>
    /// <returns>List of bicycles of a certain type</returns>
    public List<Bicycle> GetBicyclesByType(int bicycleTypeId)
    {
        var bicyclesByType = context.Bicycles
            .Include(b => b.BicycleType)
            .Where(b => b.TypeId == bicycleTypeId)
            .ToList();
        return bicyclesByType;
    }
}
