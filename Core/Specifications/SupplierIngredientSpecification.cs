using Core.Entities.Purchases;

namespace Core.Specifications;

public class SupplierIngredientSpecification : BaseSpecification<SupplierIngredient>
{
    public SupplierIngredientSpecification(string ingredientId)
        : base(sp => sp.IngredientId == ingredientId)
    {
        AddInclude(sp => sp.Ingredient);
        AddInclude(sp => sp.Supplier);
    }

    public SupplierIngredientSpecification(string supplierId, bool bySupplier)
        : base(sp => sp.SupplierId == supplierId)
    {
        AddInclude(sp => sp.Ingredient);
        AddInclude(sp => sp.Supplier);
    }

}
