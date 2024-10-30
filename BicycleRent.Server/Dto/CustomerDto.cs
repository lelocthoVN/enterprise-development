namespace BicycleRent.Server.Dto;

public class CustomerDto
{
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
}
