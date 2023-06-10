using PcBuilders.Learning.Domain.Model;
using PcBuilders.Learning.Domain.Services.Communication;

namespace PcBuilders.Learning.Domain.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> ListAsync();
    Task<IEnumerable<Product>> ListByStoreIdAsync(int storeId);
    Task<ProductResponse> SaveAsync(Product product);
    Task<ProductResponse> UpdateAsync(int productId, Product product);
    Task<ProductResponse> DeleteAsync(int productId);
}