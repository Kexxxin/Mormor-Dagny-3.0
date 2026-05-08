using Api.Dtos.Ingredients;

namespace Api.DTOs.Ingredients;

public class GetAllIngredientsDto : BaseIngredientDto
{

    public List<IngredientWithSupplierDto>? Suppliers { get; set; } = new();

}
