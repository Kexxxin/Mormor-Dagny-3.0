namespace Api.DTOs.Orders;

public class PostOrderDto
{
    public required string CustomerId { get; set; }
    public required List<PostOrderItemDto> Items { get; set; }
}
