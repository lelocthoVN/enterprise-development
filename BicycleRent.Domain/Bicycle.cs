﻿namespace BicycleRent.Domain;
/// <summary>
/// Bicycle avalible for rent
/// </summary>
public class Bicycle
{
    /// <summary>
    /// Bicycle's serial number
    /// </summary>
    public required string SerialNumber { get; set; }
    /// <summary>
    /// Bicycle's type ID 
    /// </summary>
    public required int TypeId { get; set; }
    /// <summary>
    /// Bicycle's model
    /// </summary>
    public required string Model { get; set; }
    /// <summary>
    /// Bicycle's color
    /// </summary>
    public required string Color { get; set; }
}
