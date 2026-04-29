using Api.Dtos.Ingredients;

namespace Api.DTOs.Ingredients;

public class GetIngredientDto : BaseIngredientDto
{
    public required string Id { get; set; }
    public List<IngredientWithSupplierDto>? Suppliers { get; set; }
}
