using Api.DTOs.Orders;

namespace Api.DTOs.Customers;

public class GetCustomerByIdDto : BaseCustomerDto
{
    public string Id { get; set; } = null!;
    public AddressDto InvoiceAddress { get; set; } = null!;
    public AddressDto DeliveryAddress { get; set; } = null!;
    public List<OrderTotalDto> Orders { get; set; } = [];

}
