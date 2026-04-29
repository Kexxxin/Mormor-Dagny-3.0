using Core.Entities;

namespace Core;

public class OrderItem : BaseEntity
{
    public ItemOrdered ItemOrdered { get; set; } = null!;
    public double Price { get; set; }
    public int Quantity { get; set; }
}
