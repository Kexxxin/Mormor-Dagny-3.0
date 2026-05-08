namespace Api.DTOs.Suppliers;

public class PostSupplierIngredientDto
{
    public required string IngredientId { get; set; }
    public required decimal PricePerKg { get; set; }
}
