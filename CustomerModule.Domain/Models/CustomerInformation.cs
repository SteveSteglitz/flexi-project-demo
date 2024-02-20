using System.ComponentModel.DataAnnotations;

namespace CustomerModule.Domain.Models;

public class CustomerInformation
{
    [Key]
    public Guid Id { get; set; }
    // public Guid Customer_Id { get; set; }
    public string Fieldname { get; set; }
    public string Fieldlabel { get; set; }
    public string Fieldtype { get; set; }
    public string Fieldvalue { get; set; }

    // public Customer Customer { get; set; }
}