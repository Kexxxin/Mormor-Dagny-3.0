namespace Core.Entities.Purchases;

public class SupplierIngredient : BaseEntity
{
    public string SupplierId { get; set; } = null!;
    public Supplier Supplier { get; set; } = null!;
    public string IngredientId { get; set; } = null!;
    public Ingredient Ingredient { get; set; } = null!;
    public decimal PricePerKg { get; set; }

}
