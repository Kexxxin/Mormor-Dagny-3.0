

namespace Api.DTOs.Ingredients;

public class IngredientWithSupplierDto
{
    public string? SupplierId { get; set; }
    public string? SupplierName { get; set; }
    public decimal PricePerKg { get; set; }

}
