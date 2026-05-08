namespace Api.DTOs.Products;

public class BaseProductDto
{
    public required string ProductName { get; set; }
    public required string QuantityPerPackage { get; set; }
    public required decimal ProductWeight { get; set; }
    public required decimal PricePerUnit { get; set; }
    public required DateTime BestBefore { get; set; }
    public required DateTime ProductionDate { get; set; }

}
