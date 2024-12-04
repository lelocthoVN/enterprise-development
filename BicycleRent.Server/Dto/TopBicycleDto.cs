namespace BicycleRent.Server.Dto;

/// <summary>
/// Represents the DTO for top bicycles based on rental activity
/// </summary>
public class TopBicycleDto
{
    /// <summary>
    /// The serial number of the bicycle
    /// </summary>
    public required string BicycleSerialNumber { get; set; }
    /// <summary>
    /// The model of the bicycle.
    /// </summary>
    public required string Model { get; set; }
    /// <summary>
    /// The name of the bicycle type
    /// </summary>
    public required string TypeName { get; set; }
    /// <summary>
    /// The rental count of the bicycle
    /// </summary>
    public required int RentalCount { get; set; }            
}
