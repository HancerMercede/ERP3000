using ERP3000.Repository.Conctracts;
using ERP3000.Service.Contracts;

namespace ERP3000.Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IOrderService> _orderService;
    private readonly Lazy<IProductService> _ProductService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _orderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager));
        _ProductService = new Lazy<IProductService>(() => new ProductService(repositoryManager));
    }

    public IOrderService OrderService => _orderService.Value;

    public IProductService ProductService => _ProductService.Value;
}
