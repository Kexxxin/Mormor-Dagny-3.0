namespace Core.Entities;

public class Product : BaseEntity
{
    public required string ProductName { get; set; }
    public required decimal PricePerUnit { get; set; }
    public required decimal ProductWeight { get; set; }
    public required string QuantityPerPackage { get; set; }
    public required DateTime BestBeforeDate { get; set; }
    public required DateTime ProductionDate { get; set; }

}
