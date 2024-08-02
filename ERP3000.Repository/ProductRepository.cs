using ERP3000.Entities;

namespace ERP3000.Repository;

public class ProductRepository : BaseRepository<Product>
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}

