using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BicycleRent.Domain;

/// <summary>
/// Class that represents specific rental operation
/// </summary>
public class Rental
{
    /// <summary>
    /// Rental ID
    /// </summary>
    [Key]
    public required int Id { get; set; }
    /// <summary>
    /// Bicycle rental customer ID
    /// </summary> 
    [ForeignKey("Customer")]
    public required int CustomerId { get; set; }
    /// <summary>
    /// Bicycle's SerialNumber is rented
    /// </summary>
    [ForeignKey("Bicycle")]
    public required string BicycleSerialNumber { get; set; } 
    /// <summary>
    /// The rented bicycle
    /// </summary>
    public Bicycle? Bicycle { get; set; }
    /// <summary>
    /// The customer renting the bicycle
    /// </summary>
    public Customer? Customer { get; set; }
    /// <summary>
    /// Start time of the rental
    /// </summary>
    public required DateTime Begin { get; set; }
    /// <summary>
    /// End time of the rental
    /// </summary>
    public required DateTime End { get; set; }
}