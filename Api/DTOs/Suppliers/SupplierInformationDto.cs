namespace Api.DTOs.Suppliers;

public class SupplierInformationDto
{
    public required string SupplierName { get; set; }
    public required string Address { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public List<SupplierWithIngredientDto>? Ingredients { get; set; }
}
