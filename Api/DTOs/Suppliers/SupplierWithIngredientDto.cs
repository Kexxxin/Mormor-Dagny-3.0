namespace Api.DTOs.Suppliers;

public class SupplierWithIngredientDto : BaseSupplierDto
{
    public int IngredientId { get; set; }
    public required string IngredientName { get; set; }
    public required decimal PricePerKg { get; set; }
    public string? Description { get; set; }
}
