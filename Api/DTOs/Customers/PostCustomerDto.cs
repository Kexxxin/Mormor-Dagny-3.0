namespace Api.DTOs.Customers;

public class PostCustomerDto : BaseCustomerDto
{
    public AddressDto InvoiceAddress { get; set; } = null!;
    public AddressDto DeliveryAddress { get; set; } = null!;

}
