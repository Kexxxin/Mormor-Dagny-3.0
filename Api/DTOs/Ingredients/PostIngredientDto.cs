using Api.Dtos.Ingredients;

namespace Api.DTOs.Ingredients;

public class PostIngredientDto : BaseIngredientDto
{
    public required string IngredientName { get; set; }
}
