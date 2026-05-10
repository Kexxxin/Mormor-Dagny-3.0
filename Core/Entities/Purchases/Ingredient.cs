namespace Core.Entities.Purchases;

public class Ingredient : BaseEntity
{
    public required string ItemNumber { get; set; }
    public required string IngredientName { get; set; }
    public string? Description { get; set; }
    public List<SupplierIngredient> SupplierIngredients { get; set; } = [];
}
