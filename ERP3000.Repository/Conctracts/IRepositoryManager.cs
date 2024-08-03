namespace ERP3000.Repository.Conctracts;

public interface IRepositoryManager
{
    IOrderRepository Order { get; }
    IProductRepository Product { get; }
    Task Save();
}
