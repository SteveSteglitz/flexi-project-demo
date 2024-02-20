using CustomerModule.API.DTOs;
using CustomerModule.API.Mappers;
using CustomerModule.Application;
using CustomerModule.Domain;
using CustomerModule.Domain.Interfaces;
using CustomerModule.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModule.Application;
using Swashbuckle.AspNetCore.Annotations;

namespace CustomerModule.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    private readonly CustomerMapper _mapper = new CustomerMapper();
    
    [HttpGet]
    [SwaggerOperation(Summary = "Get all customers", Description = "Retrieves a list of all customers.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Customer>))]
    public async Task<IActionResult> GetAllCustomers()
    {
        var result = await customerService.GetAllCustomers();
        if (result.ResultType != ServiceResultType.Success)
        {
            return StatusCode(500);
        }

        var customerDtos = result.Data.Select(customer => _mapper.CustomerToCustomerDto(customer));
        return Ok(customerDtos);
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a customer by ID", Description = "Retrieves a customer by their ID.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCustomerById(Guid id)
    {
        var result = await customerService.GetCustomerById(id);
        return result.ResultType switch
        {
            ServiceResultType.NotFound => NotFound(),
            ServiceResultType.Fail => StatusCode(500),
            _ => Ok(_mapper.CustomerToCustomerDto(result.Data))
        };
    }
    
    [HttpPost]
    [SwaggerOperation(Summary = "Add new customer", Description = "Add a new customer.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddNewCustomer([FromBody] CustomerDto customerDto)
    {
        var customer = _mapper.CustomerDtoToCustomer(customerDto);
        var result = await customerService.AddNewCustomer(customer);
        if (result.ResultType != ServiceResultType.Success)
        {
            return Conflict(result.Errors);
        }

        var returnDto = _mapper.CustomerToCustomerDto(result.Data);
        return CreatedAtAction(nameof(GetCustomerById), new { id = returnDto.CustomerId }, returnDto);
    }
}