using Core.Entities;
using Core.Entities.Purchases;

namespace Core.Specifications;

public class IngredientSpecification : BaseSpecification<Ingredient>
{
    public IngredientSpecification(IngredientSpecificationParams args) : base(i =>
        (string.IsNullOrEmpty(args.Search) || i.IngredientName.ToLower().Contains(args.Search.ToLower())) &&
        (string.IsNullOrWhiteSpace(args.ItemNumber) || (i.ItemNumber == args.ItemNumber)))
    {
        ApplyPagination(args.PageSize, args.PageSize * (args.PageNumber - 1));
        UseOrderByAscending(i => i.IngredientName);

    }
    public IngredientSpecification(string id) : base(i => i.Id == id)
    {
        AddInclude(i => i.SupplierIngredients);
        AddInclude("SupplierIngredient.Supplier");
    }


}
