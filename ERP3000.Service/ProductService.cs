using ERP3000.Entities;
using ERP3000.Repository.Conctracts;
using ERP3000.Service.Contracts;

namespace ERP3000.Service;

public class ProductService : IProductService
{
    private readonly IRepositoryManager _repositoryManager;

    public ProductService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public Task CreateProduct(Product model)
    {
        return _repositoryManager.Product.CreateProduct(model);
    }

    public async Task DeleteProduct(string Id, bool trackChanges)
    {
        await _repositoryManager.Product.DeleteProduct(Id, trackChanges);
    }

    public async Task<IEnumerable<Product>> GetAll(bool trackChanges)
    {
        var products = await _repositoryManager.Product.GetAll(trackChanges);
        return products;
    }

    public async Task<Product> GetByCondiction(string Id, bool trackChanges)
    {
        return await _repositoryManager.Product.GetByCondiction(Id, trackChanges);
    }

    public Task<IEnumerable<Product>> GetByIds(IEnumerable<Guid> Ids, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task SaveChanges() => _repositoryManager.Save();
}
