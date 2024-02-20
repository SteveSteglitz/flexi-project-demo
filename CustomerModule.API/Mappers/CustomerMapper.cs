using CustomerModule.API.DTOs;
using CustomerModule.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace CustomerModule.API.Mappers;

[Mapper]
public partial class CustomerMapper
{
    [MapProperty(nameof(Customer.Id), nameof(CustomerDto.CustomerId))]
    public partial CustomerDto CustomerToCustomerDto(Customer customer);
    
    [MapProperty(nameof(CustomerDto.CustomerId), nameof(Customer.Id))]
    public partial Customer CustomerDtoToCustomer(CustomerDto customer);
}