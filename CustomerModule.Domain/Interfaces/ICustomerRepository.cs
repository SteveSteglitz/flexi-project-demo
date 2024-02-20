using CustomerModule.Domain.Models;

namespace CustomerModule.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllCustomers();
    Task<Customer> GetCustomerById(Guid customerId);
    Task<Customer> CreateCustomer(Customer customer);
}