using Core.Entities;

namespace Core.Entities;

public class SupplierIngredient : BaseEntity
{
    public Supplier? Supplier { get; set; }
    public Ingredient? Ingredient { get; set; }
    public decimal PricePerKg { get; set; }

}
