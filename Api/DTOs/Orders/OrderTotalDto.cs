namespace Api.DTOs.Orders;

public class OrderTotalDto
{
    public string Id { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public string OrderNumber { get; set; } = null!;
    public decimal SubTotal { get; set; }
    public List<GetOrderItemDto> Items { get; set; } = [];
}
