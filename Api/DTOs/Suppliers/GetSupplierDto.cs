namespace Api.DTOs.Suppliers;

public class GetSupplierDto
{
    public required string Id { get; set; }
    public required string ContactPerson { get; set; }
    public required string Phone { get; set; }
}
