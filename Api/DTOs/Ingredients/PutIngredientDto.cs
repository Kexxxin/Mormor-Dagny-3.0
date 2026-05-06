using Api.Dtos.Ingredients;

namespace Api.DTOs.Ingredients;

public class PutIngredientDto : BaseIngredientDto
{
    public required string IngredientName { get; set; }
}
