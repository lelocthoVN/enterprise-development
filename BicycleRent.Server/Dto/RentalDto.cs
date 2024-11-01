using BicycleRent.Domain;

namespace BicycleRent.Server.Dto;

/// <summary>
/// DTO class for representing the rentals
/// </summary>
public class RentalDto
{
    /// <summary>
    /// The rented bicycle
    /// </summary>
    public required Bicycle Bicycle { get; set; }
    /// <summary>
    /// The customer renting the bicycle
    /// </summary>
    public required Customer Customer { get; set; }
    /// <summary>
    /// Start time of the rental
    /// </summary>
    public required DateTime Begin { get; set; }
    /// <summary>
    /// End time of the rental
    /// </summary>
    public required DateTime End { get; set; }

}
