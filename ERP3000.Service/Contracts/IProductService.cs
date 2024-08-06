

using ERP3000.Entities;

namespace ERP3000.Service.Contracts;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAll(bool trackChanges);
    Task<Product> GetByCondiction(string Id, bool trackChanges);
    Task<Product> CreateProduct(Product order);
    Task<IEnumerable<Product>> GetByIds(IEnumerable<Guid> Ids, bool trackChanges);

    Task DeleteProduct(Guid Id, bool trackChanges);

    Task SaveChanges();
}
