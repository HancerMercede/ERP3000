using ERP3000.Entities;
using ERP3000.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ERP3000.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class ProductController:ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public ProductController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var products = await _serviceManager.ProductService.GetAll(trackChanges: false);
        return Ok(products);
    }
}

