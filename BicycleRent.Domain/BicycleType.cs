namespace BicycleRent.Domain;

/// <summary>
/// Class that represents specific bicycle types
/// </summary>
public class BicycleType
{
    /// <summary>
    /// Bicycle type's ID
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Rental cost per hour
    /// </summary>
    public required double RentalPrice { get; set; }
    /// <summary>
    /// Name of the bicycle type
    /// </summary>
    public required string TypeName { get; set; }
}