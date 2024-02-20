using CustomerModule.Domain;
using CustomerModule.Domain.Interfaces;
using CustomerModule.Domain.Models;
using CustomerModule.Infrastructure;
using SharedModule.Application;

namespace CustomerModule.Application;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    public async Task<ServiceResult<IEnumerable<Customer>>> GetAllCustomers()
    {
        var customers = await customerRepository.GetAllCustomers();
        return customers == null
            ? ServiceResult<IEnumerable<Customer>>.Fail("Load customers faild")
            : ServiceResult<IEnumerable<Customer>>.Success(customers);
    }

    public async Task<ServiceResult<Customer>> GetCustomerById(Guid customerId)
    {
        var customer = await customerRepository.GetCustomerById(customerId);
        return customer == null ? ServiceResult<Customer>.NotFound() : ServiceResult<Customer>.Success(customer);
    }
    
    public async Task<ServiceResult<Customer>> AddNewCustomer(Customer customer)
    {
        var newCustomer = await customerRepository.CreateCustomer(customer);
        return newCustomer == null ? ServiceResult<Customer>.Fail("Create customer failed") : ServiceResult<Customer>.Success(newCustomer);
    }
}