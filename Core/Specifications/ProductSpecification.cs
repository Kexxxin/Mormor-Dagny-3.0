namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(ProductSpecificationParams args) : base(c =>
        (string.IsNullOrEmpty(args.Search) || c.ProductName.ToLower().Contains(args.Search.ToLower())) &&
        (string.IsNullOrWhiteSpace(args.ItemNumber) || (c.ItemNumber == args.ItemNumber)))
    {

        ApplyPagination(args.PageSize, args.PageSize * (args.PageNumber - 1));

        switch (args.Sort)
        {
            case "priceAsc":
                UseOrderByAscending(c => c.PricePerUnit);
                break;
            case "priceDesc":
                UseOrderByDescending(c => c.PricePerUnit);
                break;
            default:
                UseOrderByAscending(c => c.ProductName);
                break;
        }
    }

}