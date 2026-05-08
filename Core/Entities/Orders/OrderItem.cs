using Core.Entities;
using Core.Entities.Orders;

namespace Core;

public class OrderItem : BaseEntity
{
    public ItemOrdered ItemOrdered { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
