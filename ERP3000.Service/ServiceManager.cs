using ERP3000.Repository.Conctracts;
using ERP3000.Service.Contracts;

namespace ERP3000.Service;

public class ServiceManager: IServiceManager
{
    private readonly Lazy<IOrderService> _orderService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _orderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager));
    }

    public IOrderService OrderService => _orderService.Value;
}
