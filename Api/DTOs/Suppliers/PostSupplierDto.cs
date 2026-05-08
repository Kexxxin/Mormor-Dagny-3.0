

namespace Api.DTOs.Suppliers;

public class PostSupplierDto
{
    public required string Name { get; set; }
    public required string ContactPerson { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public string? Address { get; set; }

}
