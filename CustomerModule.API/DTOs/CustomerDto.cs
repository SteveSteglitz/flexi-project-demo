namespace CustomerModule.API.DTOs;

public class CustomerDto
{
    public Guid? CustomerId { get; set; }
    public string Forename { get; set; }
    public string Surname { get; set; }
    
    public ICollection<CustomerInformationDto> CustomerInfos { get; set; }
}