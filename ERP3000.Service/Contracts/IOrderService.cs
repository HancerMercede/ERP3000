using ERP3000.Entities;
namespace ERP3000.Service.Contracts;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAll(bool trackChanges);
    Task<Order> GetByCondiction(Guid Id, bool trackChanges);
    Task<Order> CreateOrder(Order order);
    Task<IEnumerable<Order>> GetByIds(IEnumerable<Guid> Ids, bool trackChanges);

    Task DeleteOrder(Guid Id, bool trackChanges);

    Task SaveChanges();
}
