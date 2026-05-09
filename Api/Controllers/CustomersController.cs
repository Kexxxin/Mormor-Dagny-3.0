using Api.DTOs.Customers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;



public class CustomersController(IUnitOfWork uow, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddCustomer(PostCustomerDto model)
    {
        try
        {
            var customer = mapper.Map<Customer>(model);

            uow.Repository<Customer>().Add(customer);

            if (!await uow.Complete())
                return BadRequest("Kunde inte spara kunden.");

            return Ok(mapper.Map<GetCustomerDto>(customer));
        }
        catch
        {
            return StatusCode(500, "Ett server fel inträffade.");
        }
    }

    [HttpGet]
    public async Task<ActionResult> ListAllCustomers([FromQuery] CustomerSpecificationParams args)
    {
        try
        {
            var spec = new CustomerSpecification(args);
            var customers = await uow.Repository<Customer>().ListAsync(spec);

            return Ok(mapper.Map<IReadOnlyList<GetCustomerDto>>(customers));
        }
        catch
        {
            return StatusCode(500, "Ett server fel inträffade.");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCustomer(string id)
    {
        try
        {
            var spec = new CustomerWithOrdersSpecification(id);
            var customer = await uow.Repository<Customer>().FindAsync(spec);

            if (customer == null) return NotFound("Kunde inte hitta kund");

            return Ok(mapper.Map<GetCustomerByIdDto>(customer));
        }
        catch
        {
            return StatusCode(500, "Ett server fel inträffade.");
        }
    }

    [HttpPatch("{id}/contactperson")]
    public async Task<ActionResult> UpdateCustomer(string id, PatchCustomerDto model)
    {
        try
        {
            var customer = await uow.Repository<Customer>().FindByIdAsync(id);
            if (customer == null) return NotFound();

            customer.ContactPerson = model.ContactPerson;

            uow.Repository<Customer>().Update(customer);

            if (!await uow.Complete())
                return BadRequest("Kunde inte uppdatera kontaktpersonen.");

            return Ok(mapper.Map<GetCustomerDto>(customer));
        }
        catch
        {
            return StatusCode(500, "Ett server fel inträffade.");
        }
    }
}

