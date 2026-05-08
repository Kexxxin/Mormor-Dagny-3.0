namespace Core.Entities.Purchases;

public class Supplier : BaseEntity
{
    public required string SupplierName { get; set; }
    public required string ContactPerson { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required Address Address { get; set; }
    public List<SupplierIngredient> SupplierIngredients { get; set; } = [];

}
