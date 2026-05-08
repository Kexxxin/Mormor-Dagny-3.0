using Core.Entities.Purchases;

namespace Core.Specifications;

public class SupplierSpecification : BaseSpecification<Supplier>
{
    public SupplierSpecification(SupplierSpecificationParams args)
        : base(s =>
            string.IsNullOrWhiteSpace(args.SupplierName) ||
            s.SupplierName.ToLower().Contains(args.SupplierName.ToLower()))
    {
        AddInclude(s => s.SupplierIngredients);
        AddInclude("SupplierIngredients.Ingredient");

        UseOrderByAscending(s => s.SupplierName);

        ApplyPagination(args.PageSize, args.PageSize * (args.PageNumber - 1));
    }
}
public class SupplierByIdSpecification : BaseSpecification<Supplier>
{
    public SupplierByIdSpecification(string id) : base(s => s.Id == id)
    {
        AddInclude(s => s.SupplierIngredients);
        AddInclude("SupplierIngredients.Ingredient");

    }
}
