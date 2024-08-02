using ERP3000.Entities;

namespace ERP3000.Repository.Conctracts;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAll(bool trackChanges);
    Task<Order> GetByCondiction(Guid OrderId, bool trackChanges);
}
