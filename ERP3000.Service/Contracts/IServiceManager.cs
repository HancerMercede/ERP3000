
namespace ERP3000.Service.Contracts;

public interface IServiceManager
{
    IOrderService OrderService { get;  }
    IProductService ProductService { get; }
}
