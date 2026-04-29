using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Core;

public class Supplier : BaseEntity
{
    public required string SupplierName { get; set; }
    public required string ContactPerson { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public List<SupplierIngredient>? SupplierIngredients { get; set; }
}
