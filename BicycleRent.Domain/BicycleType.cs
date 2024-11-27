using System.ComponentModel.DataAnnotations;

namespace BicycleRent.Domain;

/// <summary>
/// Class that represents specific bicycle types
/// </summary>
public class BicycleType
{
    /// <summary>
    /// Bicycle type's ID
    /// </summary>
    [Key]
    public required int Id { get; set; }
    /// <summary>
    /// Rental cost per hour
    /// </summary>
    public required double RentalPrice { get; set; }
    /// <summary>
    /// Name of the bicycle type
    /// </summary>
    public required string TypeName { get; set; }
    /// <summary>
    /// Navigation property to Bicycles 
    /// </summary>
    public ICollection<Bicycle> Bicycles { get; set; } = new List<Bicycle>();
}