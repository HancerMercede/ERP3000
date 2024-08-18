using Microsoft.IdentityModel.Tokens;

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

        _logger.LogInformation("Returning not found if the product does not exist.");
        if (productEntity is null) return NotFound($"The product with Id:{Id} does not exist.");

        _logger.LogInformation("Adapting the product.");
        var productDto = productEntity.Adapt<ProductDto>();

        _logger.LogInformation("Returning teh product.");
        return Ok(productDto);
    }

    [HttpPost(Name = "Create a new product")]
    public async Task<ActionResult<ProductDto>> CreateProduct([FromForm]ProductCreateDto model)
    {
        try
        {
            if (model is null) return BadRequest("The product can not be null");
            
            _logger.LogInformation("Creating the default Id");
            model.ProductId =  Guid.NewGuid().ToString();

            var dbEntity = model.Adapt<Product>();

            await _serviceManager.ProductService.CreateProduct(dbEntity);
            await _serviceManager.ProductService.SaveChanges();

            var productDto = dbEntity.Adapt<ProductDto>();

            return new CreatedAtRouteResult("GetProduct", new { Id = model.ProductId }, model);
        }
        catch (Exception)
        {

            throw;
        }
    
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

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(string Id)
    {
        try
        {
            _logger.LogInformation("Returning bad request, if the product id is null.");
            if (Id.IsNullOrEmpty()) return BadRequest($"the Id can be null");

            _logger.LogInformation("Deleting the product.");
            await _serviceManager.ProductService.DeleteProduct(Id, trackChanges: true);
           
            await _serviceManager.ProductService.SaveChanges();

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error:{ex.Message}");
            throw new Exception(ex.Message);
        }
       
    }
}

