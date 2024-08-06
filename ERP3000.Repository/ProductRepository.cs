using ERP3000.Entities;
using ERP3000.Repository.Conctracts;
using Microsoft.EntityFrameworkCore;

namespace ERP3000.Repository;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }


    public async Task<IEnumerable<Product>> GetAll(bool trackChanges) {
        var products = await FindAll(trackChanges).ToListAsync();
        return products;
    }
    public async Task<Product> GetByCondiction(string ProductId, bool trackChanges)
    {
        var product = await FindByCondiction(p=>p.ProductId == ProductId, trackChanges).FirstOrDefaultAsync();
        return product!;
    }

    public Task DeleteProduct(string Id)
    {
        throw new NotImplementedException();
    }


}

