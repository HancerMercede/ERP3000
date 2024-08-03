using ERP3000.Entities;

namespace ERP3000.Repository.Conctracts;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll(bool trackChanges);
    Task<Product> GetByCondiction(string ProductId, bool trackChanges);
}
