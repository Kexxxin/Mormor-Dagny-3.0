namespace Api.DTOs.Orders;

public class GetOrdersDto
{
    public string Id { get; set; } = null!;
    public string CustomerName { get; set; } = null!;
    public string CustomerEmail { get; set; } = null!;
    public string CustomerContact { get; set; } = null!;
    public string OrderNumber { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public List<GetOrderItemDto> Items { get; set; } = null!;
    public decimal SubTotal { get; set; }

}
