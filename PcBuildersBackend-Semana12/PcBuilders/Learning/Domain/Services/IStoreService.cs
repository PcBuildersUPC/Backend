using PcBuilders.Learning.Domain.Model;
using PcBuilders.Learning.Domain.Services.Communication;

namespace PcBuilders.Learning.Domain.Services;

public interface IStoreService
{
    Task<IEnumerable<Store>> ListAsync();
    Task<StoreResponse> SaveAsync(Store store);
    Task<StoreResponse> UpdateAsync(int id, Store store);
    Task<StoreResponse> DeleteAsync(int id);
}