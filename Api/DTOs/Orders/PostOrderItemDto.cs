namespace Api.DTOs.Orders;

public class PostOrderItemDto
{
    public required string ProductId { get; set; }
    public required int Quantity { get; set; }

}
