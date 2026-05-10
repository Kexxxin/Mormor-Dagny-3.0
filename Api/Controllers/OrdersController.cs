using Api.DTOs.Orders;
using AutoMapper;
using Core.Entities.Orders;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class OrdersController(IUnitOfWork uow, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> ListAllOrders([FromQuery] OrderSpecificationParams args)
    {
        var spec = new OrderSpecification(args);
        var orders = await uow.Repository<Order>().ListAsync(spec);

        return Ok(mapper.Map<IReadOnlyList<GetOrdersDto>>(orders));
    }

    [HttpPost]
    public async Task<ActionResult> AddOrder(PostOrderDto model)
    {
        var order = mapper.Map<Order>(model);

        uow.Repository<Order>().Add(order);

        if (!await uow.Complete()) return BadRequest("Kunde inte spara order!");

        return Ok(mapper.Map<GetOrdersDto>(order));
    }


    [HttpGet("{id}")]
    public async Task<ActionResult> FindOrderById(string id)
    {
        var spec = new OrderSpecification(id);
        var order = await uow.Repository<Order>().FindAsync(spec);

        if (order == null) return NotFound("Kunde inte hitta ordern");

        return Ok(mapper.Map<GetOrdersDto>(order));
    }
}