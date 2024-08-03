using ERP3000.Entities;
using ERP3000.Repository.Conctracts;
using ERP3000.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP3000.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    public OrderController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
    {
        var orders = await _serviceManager.OrderService.GetAll(trackChanges:false);
        return Ok(orders);
    }
    [HttpGet("{Id}")]
    public async Task<ActionResult<Order>> GetByCondiction(Guid Id)
    {
        var order = await _serviceManager.OrderService.GetByCondiction(Id, trackChanges: false);
        return Ok(order);
    }
}
