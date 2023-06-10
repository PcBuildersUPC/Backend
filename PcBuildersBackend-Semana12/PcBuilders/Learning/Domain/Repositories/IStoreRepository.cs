using PcBuilders.Learning.Domain.Model;

namespace PcBuilders.Learning.Domain.Repositories;

public interface IStoreRepository
{
    Task<IEnumerable<Store>> ListAsync();
    Task AddAsync(Store category);
    Task<Store> FindByIdAsync(int id);
    void Update(Store category);
    void Remove(Store category);
}