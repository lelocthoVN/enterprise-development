using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BicycleRent.Domain;

/// <summary>
/// Class that represents specific bicycle available for rent
/// </summary>
// [Table("bicycle")]
public class Bicycle
{
    /// <summary>
    /// Bicycle's serial number (Primary Key)
    /// </summary>
    [Key]
    public required string SerialNumber { get; set; }
    /// <summary>
    /// Bicycle's type ID 
    /// </summary>
    [ForeignKey("BicycleType")]
    public required int TypeId { get; set; }
    /// <summary>
    /// Bicycle's model
    /// </summary>
    public required string Model { get; set; }
    /// <summary>
    /// Bicycle's color
    /// </summary>
    public required string Color { get; set; }
    /// <summary>
    /// Navigation property to BicycleType
    /// </summary>
    public required BicycleType BicycleType { get; set; }
    /// <summary>
    /// Navigation property to Rentals 
    /// </summary>
    public required ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}