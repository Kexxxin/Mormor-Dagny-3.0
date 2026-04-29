using Api.Dtos.Ingredients;

namespace Api.DTOs.Ingredients;

public class GetAllIngredientsDto : BaseIngredientDto
{
    public required string Id { get; set; }
    public List<IngredientWithSupplierDto>? Suppliers { get; set; }

}
