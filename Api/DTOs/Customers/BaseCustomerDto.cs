namespace Api.DTOs.Customers;

public class BaseCustomerDto
{
    public string CompanyName { get; set; } = null!;
    public string? ContactPerson { get; set; }
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;

}
