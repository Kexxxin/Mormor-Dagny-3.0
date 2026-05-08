namespace Api.DTOs.Orders;

public class GetOrderItemDto
{
    public required string ProductName { get; set; }
    public required int Quantity { get; set; }
    public required decimal Price { get; set; }
    public required decimal SubTotal { get; set; }

}
