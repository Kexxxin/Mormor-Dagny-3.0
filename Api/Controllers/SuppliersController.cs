using Api.DTOs.Suppliers;
using AutoMapper;
using Core.Entities.Purchases;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class SuppliersController(IUnitOfWork uow, IMapper mapper) : ApiBaseController
{
    [HttpGet]
    public async Task<ActionResult> ListAllSuppliers([FromQuery] SupplierSpecificationParams args)
    {
        var spec = new SupplierSpecification(args);
        var result = await uow.Repository<Supplier>().ListAsync(spec);
        return await CreatePagedResult(uow.Repository<Supplier>(), spec, args.PageNumber, args.PageSize, result);

    }

    [HttpGet("{supplierId}/ingredients")]
    public async Task<ActionResult> ListAllSupplierWithIngredientsAndPrice(string supplierId)
    {
        try
        {
            var spec = new SupplierIngredientSpecification(supplierId, bySupplier: true);
            var supplierIngredients = await uow.Repository<SupplierIngredient>().ListAsync(spec);

            if (supplierIngredients == null || supplierIngredients.Count == 0)
                return NotFound("Något gick fel vid hämtning");

            var supplier = supplierIngredients.First().Supplier;

            var model = new GetSupplierIngredientsDto
            {
                Id = supplier.Id,
                SupplierName = supplier.SupplierName,
                ContactPerson = supplier.ContactPerson,
                Email = supplier.Email,
                Phone = supplier.Phone,
                Ingredients = supplierIngredients.Select(sp => new SupplierWithIngredientDto
                {
                    IngredientId = sp.IngredientId,
                    IngredientName = sp.Ingredient.IngredientName,
                    Description = sp.Ingredient.Description,
                    PricePerKg = sp.PricePerKg
                }).ToList()
            };

            return Ok(model);
        }
        catch
        {
            return StatusCode(500, "Ett serverfel inträffade.");
        }
    }


    [HttpGet("{id}")]
    public async Task<ActionResult> GetSupplierById(string id)
    {
        var spec = new SupplierByIdSpecification(id);
        var supplier = await uow.Repository<Supplier>().FindAsync(spec);

        if (supplier == null) return NotFound("Kunde inte hitta leverantören");

        return Ok(supplier);
    }

    [HttpPost("{supplierId}/ingredients")]
    public async Task<ActionResult> AddIngredientToSupplier(string supplierId, PostSupplierIngredientDto dto)
    {
        try
        {
            var supplier = await uow.Repository<Supplier>().FindByIdAsync(supplierId);
            if (supplier == null) return NotFound("Leverantör hittades inte.");

            var supplierIngredient = new SupplierIngredient
            {
                SupplierId = supplierId,
                IngredientId = dto.IngredientId,
                PricePerKg = dto.PricePerKg
            };

            uow.Repository<SupplierIngredient>().Add(supplierIngredient);

            if (!await uow.Complete())
                return BadRequest("Kunde inte spara ändringarna.");

            return Ok(supplierIngredient);
        }
        catch
        {
            return StatusCode(500, "Ett serverfel inträffade.");
        }
    }

    [HttpPatch("{supplierId}/ingredients/{ingredientId}/price")]
    public async Task<ActionResult> UpdateSupplierIngredientPrice(string supplierId, string ingredientId, PutSupplierIngredientDto dto)
    {
        try
        {
            var spec = new SupplierIngredientSpecification(supplierId, ingredientId);
            var supplierIngredient = await uow.Repository<SupplierIngredient>().FindAsync(spec);

            if (supplierIngredient == null) return NotFound("Ingrediensen matchar inte leverantören");

            supplierIngredient.PricePerKg = dto.PricePerKg;

            uow.Repository<SupplierIngredient>().Update(supplierIngredient);

            if (!await uow.Complete())
                return BadRequest("Kunde inte uppdatera priset.");

            return Ok(supplierIngredient);
        }
        catch
        {
            return StatusCode(500, "Ett serverfel inträffade.");
        }
    }



}
