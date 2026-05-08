

namespace Api.DTOs
{
    public class AddressDto
    {
        public required string AddressLine { get; set; } = string.Empty;
        public required string City { get; set; } = string.Empty;
        public required string PostalCode { get; set; } = string.Empty;

    }
}