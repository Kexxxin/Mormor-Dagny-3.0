using Core.Entities;

namespace Core;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public string? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];
    public required double SubTotal { get; set; }

    public double GetTotalAmount()
    {
        return SubTotal + OrderItems.Sum(p => p.Price * p.Quantity);
    }


}
