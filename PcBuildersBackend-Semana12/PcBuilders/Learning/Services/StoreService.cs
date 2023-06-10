using PcBuilders.Learning.Domain.Model;
using PcBuilders.Learning.Domain.Repositories;
using PcBuilders.Learning.Domain.Services;
using PcBuilders.Learning.Domain.Services.Communication;

namespace PcBuilders.Learning.Services;

public class StoreService :IStoreService
{
    private readonly IStoreRepository _storeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public StoreService(IStoreRepository storeRepository, IUnitOfWork unitOfWork)
    {
        _storeRepository = storeRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Store>> ListAsync()
    {
        return await _storeRepository.ListAsync();
    }

    public async Task<StoreResponse> SaveAsync(Store store)
    {
        try
        {
            await _storeRepository.AddAsync(store);
            await _unitOfWork.CompleteAsync();
            return new StoreResponse(store);
        }
        catch (Exception e)
        {
            return new StoreResponse($"An error occurred while saving the store: {e.Message}");
        }
    }

    public async Task<StoreResponse> UpdateAsync(int id, Store store)
    {
        var exisitingStore = await _storeRepository.FindByIdAsync(id);

        if (exisitingStore == null)
            return new StoreResponse("Store not found.");

        exisitingStore.Name = store.Name;

        try
        {
            _storeRepository.Update(exisitingStore);
            await _unitOfWork.CompleteAsync();

            return new StoreResponse(exisitingStore);
        }
        catch (Exception e)
        {
            return new StoreResponse($"An error occurred while updating the store: {e.Message}");
        }
    }

    public async Task<StoreResponse> DeleteAsync(int id)
    {
        var exisitingStore = await _storeRepository.FindByIdAsync(id);

        if (exisitingStore == null)
            return new StoreResponse("Store not found.");

        try
        {
            _storeRepository.Remove(exisitingStore);
            await _unitOfWork.CompleteAsync();

            return new StoreResponse(exisitingStore);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new StoreResponse($"An error occurred while deleting the store: {e.Message}");
        }
    }
}