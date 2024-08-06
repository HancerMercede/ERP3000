namespace ERP3000.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IServiceManager serviceManager, ILogger<ProductController> logger)
    {
        _serviceManager = serviceManager;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        _logger.LogInformation("Getting all the entities.");
        var products = await _serviceManager.ProductService.GetAll(trackChanges: false);


        _logger.LogInformation("Mapping the entity to the dto models.");
        var productsDtos = products.Adapt<IEnumerable<ProductDto>>();

        _logger.LogInformation($"Returning the dtos {productsDtos.Count()}");
        return Ok(productsDtos);
    }

    [HttpGet("{Id}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDto>> GetById(string Id)
    {
        var productEntity = await _serviceManager.ProductService.GetByCondiction(Id, trackChanges: false);
        var productDto = productEntity.Adapt<ProductDto>();
        return Ok(productDto);
    }
    [HttpPut]
    public async Task<IActionResult> Update(string Id, [FromBody] ProductUpdateDto modelToUpdate)
    {
        if (modelToUpdate is null)
        {
            _logger.LogInformation("The model can not be null");
            return BadRequest($"Model can not be null, please verify.");
        }

        var modelEntity = await _serviceManager.ProductService.GetByCondiction(Id, trackChanges: true);
        if (modelEntity is null)
        {
            _logger.LogInformation($"The model with id:{Id} does not exist in the database, please verify.");
            return BadRequest($"The model with id:{Id} does not exist in the database, please verify.");
        }

        modelToUpdate.Adapt(modelEntity);
        await _serviceManager.ProductService.SaveChanges();

        return NoContent();
    }
}

