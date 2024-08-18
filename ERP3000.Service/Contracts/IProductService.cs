

using ERP3000.Entities;

namespace ERP3000.Service.Contracts;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAll(bool trackChanges);
    Task<Product> GetByCondiction(string Id, bool trackChanges);
    Task CreateProduct(Product order);
    Task<IEnumerable<Product>> GetByIds(IEnumerable<Guid> Ids, bool trackChanges);

    Task DeleteProduct(string Id, bool trackChanges);

    Task SaveChanges();
}
