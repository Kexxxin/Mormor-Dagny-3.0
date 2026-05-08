using Api.Dtos.Ingredients;

namespace Api.DTOs.Ingredients;

public class GetIngredientDto : BaseIngredientDto
{
    public List<IngredientWithSupplierDto>? Suppliers { get; set; } = new();
}
