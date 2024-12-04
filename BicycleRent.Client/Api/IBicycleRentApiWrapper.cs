namespace BicycleRent.Client.Api;

/// <summary>
/// Interface for interacting with the BicycleRent server API.
/// </summary>
public interface IBicycleRentApiWrapper
{
    /// <summary>
    /// Retrieves all bicycles in the system
    /// </summary>
    /// <returns>A collection of all bicycles</returns>
    Task<ICollection<BicycleDto>> GetAllBicycles();

    /// <summary>
    /// Retrieves the top five most rented bicycles
    /// </summary>
    /// <returns>A collection of the top five bicycles</returns>
    Task<ICollection<TopBicycleDto>> GetTopFiveBicycles();

    /// <summary>
    /// Adds a new customer to the system
    /// </summary>
    /// <param name="customer">The customer to add</param>
    /// <returns>The added customer</returns>
    Task<CustomerDto> PostCustomer(CustomerDto customer);

    /// <summary>
    /// Retrieves a customer by their ID
    /// </summary>
    /// <param name="id">The ID of the customer to retrieve</param>
    /// <returns>The customer with the specified ID</returns>
    Task<CustomerDto> GetCustomerById(int id);

    /// <summary>
    /// Retrieves the top customers based on their rental activities
    /// </summary>
    /// <returns>A collection of the top customers</returns>
    Task<ICollection<TopCustomerDto>> GetTopCustomers();

    /// <summary>
    /// Retrieves all bicycle types
    /// </summary>
    /// <returns>A collection of all bicycle types</returns>
    Task<ICollection<BicycleTypeDto>> GetAllBicycleTypes();

    /// <summary>
    /// Deletes a rental by its ID
    /// </summary>
    /// <param name="id">The ID of the rental to delete</param>
    /// <returns>A message confirming the deletion</returns>
    Task<string> DeleteRental(int id);

    /// <summary>
    /// Retrieves all rentals in the system
    /// </summary>
    /// <returns>A collection of all rentals</returns>
    Task<ICollection<RentalDto>> GetAllRentals();

    /// <summary>
    /// Get list of bicycles that have not been rented yet
    /// </summary>
    /// <returns>List of bicycles of a certain type</returns>
    Task<ICollection<BicycleWithTypeNameDto>> GetAvailableBicycles();

    /// <summary>
    /// Get a list of bicycles of a certain type
    /// </summary>
    /// <param name="bicycleTypeId">ID of the bicycle type</param>
    /// <returns>List of bicycles of a certain type</returns>
    Task<ICollection<BicycleWithTypeNameDto>> GetBicyclesByType(int bicycleTypeId);
}




