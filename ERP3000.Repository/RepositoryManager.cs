using ERP3000.Repository.Conctracts;

namespace ERP3000.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationDbContext _context;
    private readonly Lazy<IOrderRepository> _orderRepository;
    private readonly Lazy<IProductRepository> _productRepository;

    public RepositoryManager( ApplicationDbContext context)
    {
        _context = context;
        _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(_context));
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(context));
    }

    public IOrderRepository Order => _orderRepository?.Value!;

    public IProductRepository Product => _productRepository?.Value!;

    public Task Save()=> _context.SaveChangesAsync();
}
