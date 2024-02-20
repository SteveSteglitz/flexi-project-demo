using CustomerModule.Domain;
using CustomerModule.Domain.Interfaces;
using CustomerModule.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerModule.Infrastructure;

public class CustomerRepository(ApplicationDbContext dbContext) : ICustomerRepository
{
    public async Task<IEnumerable<Customer>> GetAllCustomers()
    {
        return await dbContext.Customer.Include(c => c.CustomerInfos).ToListAsync();
    }

    public async Task<Customer> GetCustomerById(Guid customerId)
    {
        return await dbContext.Customer.Include(c => c.CustomerInfos).FirstOrDefaultAsync(c => c.Id == customerId);
    }

    public async Task<Customer> CreateCustomer(Customer customer)
    {
        await dbContext.Customer.AddAsync(customer);
        await dbContext.SaveChangesAsync();
        return customer;
    }
}