namespace BicycleRent.Server.Dto;

/// <summary>
/// DTO class for representing the rentals
/// </summary>
public class RentalDto
{
    /// <summary>
    /// Rental ID
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Bicycle's SerialNumber being rented
    /// </summary>
    public required string BicycleSerialNumber { get; set; }
    /// <summary>
    /// Customer ID renting the bicycle
    /// </summary>
    public required int CustomerId { get; set; }
    /// <summary>
    /// Start time of the rental
    /// </summary>
    public required DateTime Begin { get; set; }
    /// <summary>
    /// End time of the rental
    /// </summary>
    public required DateTime End { get; set; }

}
