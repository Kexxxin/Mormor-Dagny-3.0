using Core.Entities;

namespace Core.Specifications;

public class IngredientSpecification : BaseSpecification<Ingredient>
{
    public IngredientSpecification(IngredientSpecificationParams args) : base(c =>
        (string.IsNullOrEmpty(args.Search) || c.IngredientName.ToLower().Contains(args.Search.ToLower())) &&
        (string.IsNullOrWhiteSpace(args.ItemNumber) || (c.ItemNumber == args.ItemNumber)))
    {


        ApplyPagination(args.PageSize, args.PageSize * (args.PageNumber - 1));

        switch (args.Sort)
        {

            default:
                UseOrderByAscending(c => c.IngredientName);
                break;
        }
    }


}
