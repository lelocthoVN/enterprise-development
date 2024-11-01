using BicycleRent.Domain.Interfaces;

namespace BicycleRent.Domain.Repositories;

public class CustomerRepository : IRepository<Customer, int>
{
    private static readonly List<Customer> _customers = [];
    private static int _nextId = 0;

    /// <summary>
    /// Get all customers
    /// </summary>
    public IEnumerable<Customer> GetAll() => _customers;

    /// <summary>
    /// Get a customer by their ID
    /// </summary>
    /// <param name="id">The ID of the customer</param>
    public Customer? GetById(int id) => _customers.FirstOrDefault(x => x.Id == id);

    /// <summary>
    /// Delete a customer by their ID
    /// </summary>
    /// <param name="id">The ID of the customer</param>
    public bool Delete(int id)
    {
        var customer = GetById(id);
        if (customer == null)
        {
            return false;
        }
        _customers.Remove(customer);
        return true;
    }

    /// <summary>
    /// Update a customer's information
    /// </summary>
    /// <param name="entity">The customer entity with updated information</param>
    /// <param name="id">The ID of the customer to update</param>
    public bool Update(Customer entity, int id)
    {
        var existingCustomer = GetById(id);
        if (existingCustomer == null)
        {
            return false;
        }
        existingCustomer.FullName = entity.FullName;
        existingCustomer.BirthDate = entity.BirthDate;
        existingCustomer.PhoneNumber = entity.PhoneNumber;
        return true;
    }

    /// <summary>
    /// Add a new customer
    /// </summary>
    /// <param name="entity">The customer to add</param>
    public void Add(Customer entity)
    {
        if (GetById(entity.Id) == null)
        {
            entity.Id = _nextId++;
            _customers.Add(entity);
        }
    }
}
