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

}
