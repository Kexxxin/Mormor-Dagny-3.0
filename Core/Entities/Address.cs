using Core.Entities;

namespace Core;

public class Address : BaseEntity
{
    public Address() { }
    public required string AddressLine { get; set; }
    public required string PostalCode { get; set; }
    public required string City { get; set; }


}
