using System.ComponentModel.DataAnnotations;

namespace CustomerModule.Domain.Models;

public class Customer
{
    [Key]
    public Guid Id { get; set; }
    public string Forename { get; set; }
    public string Surname { get; set; }
    
    public ICollection<CustomerInformation> CustomerInfos { get; set; }
}