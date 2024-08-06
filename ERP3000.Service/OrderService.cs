using ERP3000.Entities;
using ERP3000.Repository.Conctracts;
using ERP3000.Service.Contracts;

namespace ERP3000.Service;

public class OrderService : IOrderService
{
    private readonly IRepositoryManager _repositoryManager;

    public OrderService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public Task<Order> CreateOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrder(Guid Id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Order>> GetAll(bool trackChanges)
    {
        var orders = await _repositoryManager.Order.GetAll(trackChanges);
        return orders;
    }

    public async Task<Order> GetByCondiction(Guid Id, bool trackChanges)
    {
        var order = await _repositoryManager.Order.GetByCondiction(Id, trackChanges);
        return order;
    }

    public Task<IEnumerable<Order>> GetByIds(IEnumerable<Guid> Ids, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task SaveChanges() => _repositoryManager.Save();
}
