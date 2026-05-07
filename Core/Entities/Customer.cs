using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Core;

public class Customer : BaseEntity
{
    public required string CompanyName { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public string? ContactPerson { get; set; }
    public required Address DeliveryAddress { get; set; }
    public required Address InvoiceAddress { get; set; }
    public List<Order>? Orders { get; set; }

}
