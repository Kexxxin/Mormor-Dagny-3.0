
using api.Helpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiBaseController() : ControllerBase
    {
        protected async Task<ActionResult> CreatePagedResult<T, R>(IGenericRepository<T> repo,
            ISpecification<T> args, int pageNumber, int pageSize, IReadOnlyList<R> data)
            where T : BaseEntity
        {
            var result = await repo.ListAsync(args);
            var items = await repo.CountAsync(args);
            var response = new PagedResult<T, R>(pageNumber, pageSize, items, data);

            return Ok(response);
        }

    }
}