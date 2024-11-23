using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BicycleRent.Domain;

/// <summary>
/// Class customer information for bicycle rental
/// </summary>
// [Table("customer")]
public class Customer
{
    /// <summary>
    /// Customer's ID
    /// </summary>
    [Key]
    public required int Id { get; set; }
    /// <summary>
    /// Full name of the customer
    /// </summary>
    public required string FullName { get; set; }
    /// <summary>
    /// Customer's birth date
    /// </summary>
    public required DateTime BirthDate { get; set; }
    /// <summary>
    /// Customer's phone number
    /// </summary>
    public required string PhoneNumber { get; set; }
    /// <summary>
    /// Collection of rentals associated with the customer
    /// </summary>
    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}