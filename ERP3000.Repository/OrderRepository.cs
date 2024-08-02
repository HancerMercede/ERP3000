using ERP3000.Entities;
using ERP3000.Repository.Conctracts;
using Microsoft.EntityFrameworkCore;

namespace ERP3000.Repository;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context) 
        : base(context)
    {
    }

    public async Task<Order> GetByCondiction(Guid OrderId, bool trackChanges)
    {
        var order = await FindByCondiction(c => c.OrderId == OrderId, trackChanges).FirstOrDefaultAsync();
        return order!;
    }

    public async Task<IEnumerable<Order>> GetAll(bool trackChanges)
    {
        throw new NotImplementedException();
    }
}
