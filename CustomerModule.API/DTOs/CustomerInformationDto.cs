namespace CustomerModule.API.DTOs;

public class CustomerInformationDto
{
    public Guid? Id { get; set; }
    public string Fieldname { get; set; }
    public string Fieldlabel { get; set; }
    public string Fieldtype { get; set; }
    public string Fieldvalue { get; set; }
}