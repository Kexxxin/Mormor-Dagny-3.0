namespace Core.Entities.Orders;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public string OrderNumber { get; set; } = null!;
    public string CustomerId { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
    public List<OrderItem> OrderItems { get; set; } = [];
    public decimal SubTotal => OrderItems.Sum(p => p.Price * p.Quantity);




}
