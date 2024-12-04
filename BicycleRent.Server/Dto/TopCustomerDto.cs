namespace BicycleRent.Server.Dto;

/// <summary>
/// DTO representing a top customer based on rental activity.
/// </summary>
public class TopCustomerDto
{
    /// <summary>
    /// The unique identifier of the customer.
    /// </summary>
    public required int CustomerId { get; set; }

    /// <summary>
    /// The full name of the customer.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// The total number of rentals made by the customer.
    /// </summary>
    public required int RentalCount { get; set; }
}
