﻿namespace BicycleRent.Server.Dto;

/// <summary>
/// DTO class for representing the customers
/// </summary>
public class CustomerDto
{
    /// <summary>
    /// Customer's ID
    /// </summary>
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
}
