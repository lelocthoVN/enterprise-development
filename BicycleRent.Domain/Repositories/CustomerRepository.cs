using BicycleRent.Domain.Contexts;
using BicycleRent.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BicycleRent.Domain.Repositories;

public class CustomerRepository(BicycleRentContext context) : IRepository<Customer, int>
{
    /// <summary>
    /// Get all customers
    /// </summary>
    public IEnumerable<Customer> GetAll() => context.Customers.Include(c => c.Rentals).ToList();

    /// <summary>
    /// Get a customer by their ID
    /// </summary>
    /// <param name="id">The ID of the customer</param>
    public Customer? GetById(int id) => context.Customers.Include(c => c.Rentals).FirstOrDefault(x => x.Id == id);

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
        context.Customers.Remove(customer);
        context.SaveChanges();
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
        existingCustomer.Id = entity.Id;
        existingCustomer.FullName = entity.FullName;
        existingCustomer.BirthDate = entity.BirthDate;
        existingCustomer.PhoneNumber = entity.PhoneNumber;
        context.SaveChanges();
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
            context.Customers.Add(entity);
            context.SaveChanges();
        }
    }
}
