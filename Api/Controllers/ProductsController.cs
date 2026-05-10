using Api.DTOs.Products;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class ProductsController(IUnitOfWork uow, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddProduct(PostProductDto model)
    {
        try
        {
            var product = mapper.Map<Product>(model);

            uow.Repository<Product>().Add(product);

            if (!await uow.Complete())
                return BadRequest("Kunde inte spara produkten.");

            return Ok(product);
        }
        catch
        {
            return StatusCode(500, "Ett server fel inträffade.");
        }
    }

    [HttpGet]
    public async Task<ActionResult> ListAllProducts([FromQuery] ProductSpecificationParams args)
    {
        try
        {
            var spec = new ProductSpecification(args);
            var products = await uow.Repository<Product>().ListAsync(spec);

            return Ok(mapper.Map<IReadOnlyList<GetProductDto>>(products));
        }
        catch
        {
            return StatusCode(500, "Ett server fel inträffade.");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> FindProductById(string id)
    {
        try
        {
            var spec = new ProductSpecification(id);
            var result = await uow.Repository<Product>().FindAsync(spec);

            if (result == null) return NotFound("Kunde inte hitta produkten");
            var product = mapper.Map<GetProductDto>(result);

            return Ok(product);
        }
        catch
        {
            return StatusCode(500, "Ett server fel inträffade.");
        }
    }

    [HttpPatch("{id}/price")]
    public async Task<ActionResult> UpdateProduct(string id, PatchProductDto model)
    {
        try
        {
            var product = await uow.Repository<Product>().FindByIdAsync(id);
            if (product == null)
                return NotFound();

            product.PricePerUnit = model.PricePerUnit;

            uow.Repository<Product>().Update(product);

            if (!await uow.Complete())
                return BadRequest("Kunde inte uppdatera priset.");

            return Ok(product);
        }
        catch
        {
            return StatusCode(500, "Ett server fel inträffade.");
        }
    }
}
