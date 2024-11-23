using AutoMapper;
using BicycleRent.Domain;
using BicycleRent.Domain.Repositories;
using BicycleRent.Server.Dto;

namespace BicycleRent.Server.Services;

/// <summary>
/// Service class for managing Customer operations
/// </summary>
/// <param name="repository">Repository for Customer</param>
/// <param name="mapper">Automapper instance for mapping between CustomerDto and Customer</param>
public class CustomerService(CustomerRepository repository, IMapper mapper) : IService<CustomerDto, int>
{
    /// <summary>
    /// Get all customers
    /// </summary>
    public IEnumerable<CustomerDto> GetAll() => repository.GetAll().Select(mapper.Map<CustomerDto>);

    /// <summary>
    /// Get a customer by their ID
    /// </summary>
    /// <param name="id">The ID of the customer</param>
    public CustomerDto? GetById(int id) => mapper.Map<CustomerDto>(repository.GetById(id));

    /// <summary>
    /// Delete a customer by their ID
    /// </summary>
    /// <param name="id">The ID of the customer</param>
    public bool Delete(int id) => repository.Delete(id);

    /// <summary>
    /// Update a customer's information
    /// </summary>
    /// <param name="dtoData">The CustomerDto with updated information</param>
    /// <param name="id">The id of the CustomerDto to update</param>
    public bool Update(CustomerDto dtoData, int id) => repository.Update(mapper.Map<Customer>(dtoData), id);

    /// <summary>
    /// Add a new customer
    /// </summary>
    /// <param name="dtoData">The CustomerDto to add</param>
    public void Add(CustomerDto dtoData) => repository.Add(mapper.Map<Customer>(dtoData));
}
