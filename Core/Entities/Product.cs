using Core.Entities;

namespace Core;

public class Product : BaseEntity
{
    public required string ProductName { get; set; }
    public required string ItemNumber { get; set; }
    public required double PricePerUnit { get; set; }
    public required double ProductWeight { get; set; }
    public required string QuantityPerPackage { get; set; }
    public required DateTime BestBeforeDate { get; set; }
    public required DateTime ProductionDate { get; set; }
    public List<OrderItem>? OrderItems { get; set; }

}
