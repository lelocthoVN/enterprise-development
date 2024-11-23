namespace BicycleRent.Server.Dto;

/// <summary>
/// DTO class for representing the type of bicycles
/// </summary>
public class BicycleTypeDto
{
    /// <summary>
    /// BicycleType's ID
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
