using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(ProductSpecificationParams args) : base(p =>
        string.IsNullOrEmpty(args.Search) || p.ProductName.ToLower().Contains(args.Search.ToLower())
        )
    {

        ApplyPagination(args.PageSize, args.PageSize * (args.PageNumber - 1));

        switch (args.Sort)
        {
            case "priceAsc":
                UseOrderByAscending(p => p.PricePerUnit);
                break;
            case "priceDesc":
                UseOrderByDescending(p => p.PricePerUnit);
                break;
            default:
                UseOrderByAscending(p => p.ProductName);
                break;
        }
    }

    public ProductSpecification(string id) : base(p => p.Id == id) { }

}