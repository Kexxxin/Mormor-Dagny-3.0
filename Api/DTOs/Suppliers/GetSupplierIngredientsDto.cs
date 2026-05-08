namespace Api.DTOs.Suppliers;

public class GetSupplierIngredientsDto
{
    public required string Id { get; set; }
    public required string SupplierName { get; set; }
    public required string ContactPerson { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public List<SupplierWithIngredientDto>? Ingredients { get; set; } = new();
}
