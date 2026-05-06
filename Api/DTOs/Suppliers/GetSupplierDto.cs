namespace Api.DTOs.Suppliers;

public class GetSupplierDto : BaseSupplierDto
{
    public required string ContactPerson { get; set; }
    public required string Phone { get; set; }
}
