using CustomerModule.Domain.Models;
using SharedModule.Application;

namespace CustomerModule.Domain.Interfaces;

public interface ICustomerService
{
    Task<ServiceResult<IEnumerable<Customer>>> GetAllCustomers();
    Task<ServiceResult<Customer>> GetCustomerById(Guid customerId);
    Task<ServiceResult<Customer>> AddNewCustomer(Customer customer);
}