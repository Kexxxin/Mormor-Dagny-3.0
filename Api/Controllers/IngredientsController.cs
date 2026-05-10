using Api.DTOs.Ingredients;
using AutoMapper;
using Core.Entities.Purchases;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;


public class IngredientsController(IUnitOfWork uow, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> ListAllIngredients([FromQuery] IngredientSpecificationParams args)
    {
        try
        {
            var spec = new IngredientSpecification(args);
            var ingredients = await uow.Repository<Ingredient>().ListAsync(spec);
            return Ok(mapper.Map<IReadOnlyList<GetIngredientDto>>(ingredients));


        }
        catch
        {
            return StatusCode(500, "Ett server fel inträffade.");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> FindIngredientById(string id)
    {
        try
        {
            var spec = new IngredientSpecification(id);
            var result = await uow.Repository<Ingredient>().FindAsync(spec);
            var ingredient = mapper.Map<GetIngredientDto>(result);
            if (ingredient == null) return NotFound("Ingrediensen existerar inte.");

            return Ok(ingredient);
        }
        catch
        {
            return StatusCode(500, "Ett server fel inträffade.");
        }
    }
}

