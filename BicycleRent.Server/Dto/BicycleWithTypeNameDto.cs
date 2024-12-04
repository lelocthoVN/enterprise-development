namespace BicycleRent.Server.Dto;

/// <summary>
/// DTO representing a bicycle with its type name information.
/// </summary>
public class BicycleWithTypeNameDto
{
    /// <summary>
    /// The serial number of the bicycle.
    /// </summary>
    public required string SerialNumber { get; set; }

    /// <summary>
    /// The model of the bicycle.
    /// </summary>
    public required string Model { get; set; }

    /// <summary>
    /// The color of the bicycle.
    /// </summary>
    public required string Color { get; set; }

    /// <summary>
    /// The type name of the bicycle.
    /// </summary>
    public required string TypeName { get; set; }
}
