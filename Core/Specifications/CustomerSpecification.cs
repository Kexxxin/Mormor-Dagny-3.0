using Core.Entities;

namespace Core.Specifications;

public class CustomerSpecification : BaseSpecification<Customer>
{

    public CustomerSpecification(CustomerSpecificationParams args)
        : base(c =>
            string.IsNullOrEmpty(args.Search) ||
            c.CompanyName.ToLower().Contains(args.Search.ToLower()) ||
            c.ContactPerson.ToLower().Contains(args.Search.ToLower()) ||
            c.Email.ToLower().Contains(args.Search.ToLower()))
    {
        AddInclude(c => c.Orders);

        ApplyPagination(args.PageSize, args.PageSize * (args.PageNumber - 1));

        switch (args.Sort)
        {
            case "nameDesc":
                UseOrderByDescending(c => c.CompanyName);
                break;

            case "ordersAsc":
                UseOrderByAscending(c => c.Orders.Count);
                break;

            case "ordersDesc":
                UseOrderByDescending(c => c.Orders.Count);
                break;

            default:
                UseOrderByAscending(c => c.CompanyName);
                break;
        }

    }

    public CustomerSpecification(string id)
        : base(c => c.Id == id)
    {
        AddInclude(c => c.Orders);
    }
}
