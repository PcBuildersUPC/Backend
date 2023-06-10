using PcBuilders.Learning.Domain.Model;

namespace PcBuilders.Learning.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> ListAsync();
    Task<Product> FindByIdAsync(int productId);
    Task<Product> FindByNameAsync(string name);
    Task<IEnumerable<Product>> FindByStoreIdAsync(int storeId);
    Task AddAsync(Product product);
    void Update(Product product);
    void Remove(Product product);
}