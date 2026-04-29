using Api.Dtos.Ingredients;

namespace Api.DTOs.Ingredients;

public class PutIngredientDto : PostIngredientDto
{
    public required string Id { get; set; }
}
