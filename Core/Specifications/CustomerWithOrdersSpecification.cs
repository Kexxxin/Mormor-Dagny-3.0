using Core.Entities;

namespace Core.Specifications;

public class CustomerWithOrdersSpecification : BaseSpecification<Customer>
{
    public CustomerWithOrdersSpecification(string id) : base(c => c.Id == id)
    {
        AddInclude(c => c.Orders);
        AddInclude("Orders.OrderItems");
        AddInclude("Orders.OrderItems.Product");
        AddInclude(c => c.InvoiceAddress);
        AddInclude(c => c.DeliveryAddress);

    }

}
