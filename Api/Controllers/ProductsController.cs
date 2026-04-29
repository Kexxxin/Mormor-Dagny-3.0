using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController(MormorDagnyContext context) : ControllerBase
{
}


