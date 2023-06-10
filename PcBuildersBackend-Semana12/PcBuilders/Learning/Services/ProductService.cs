using PcBuilders.Learning.Domain.Model;
using PcBuilders.Learning.Domain.Repositories;
using PcBuilders.Learning.Domain.Services;
using PcBuilders.Learning.Domain.Services.Communication;

namespace PcBuilders.Learning.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStoreRepository _storeRepository;
    
    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IStoreRepository storeRepository)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _storeRepository = storeRepository;
    }
    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _productRepository.ListAsync();
    }

    public async Task<IEnumerable<Product>> ListByStoreIdAsync(int storeId)
    {
        return await _productRepository.FindByStoreIdAsync(storeId);
    }

    public async Task<ProductResponse> SaveAsync(Product product)
    {
        // Validate CategoryId
        var existingStore = await _storeRepository.FindByIdAsync(product.StoreId);

        if (existingStore == null)
            return new ProductResponse("Invalid Store");
        
        // Validate Title
        var existingProductWithName = await _productRepository.FindByNameAsync(product.Name);

        if (existingProductWithName != null)
            return new ProductResponse("Product name already exists.");

        try
        {
            // Add Tutorial
            await _productRepository.AddAsync(product);
            
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
            
            // Return response
            return new ProductResponse(product);

        }
        catch (Exception e)
        {
            // Error Handling
            return new ProductResponse($"An error occurred while saving the product: {e.Message}");
        }
    }

    public async Task<ProductResponse> UpdateAsync(int productId, Product product)
    {
        var existingProduct = await _productRepository.FindByIdAsync(productId);
        
        // Validate Tutorial
        if (existingProduct == null)
            return new ProductResponse("Product not found.");
        // Validate CategoryId
        var existingStore = await _storeRepository.FindByIdAsync(product.StoreId);
        if (existingStore == null)
            return new ProductResponse("Invalid Store");
        // Validate Title
        var existingProductWithName = await _productRepository.FindByNameAsync(product.Name);
        if (existingProductWithName != null && existingProductWithName.Id != existingProduct.Id)
            return new ProductResponse("Product title already exists.");
        
        // Modify Fields
        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.StoreId = product.StoreId;

        try
        {
            _productRepository.Update(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new ProductResponse($"An error occurred while updating the product: {e.Message}");
        }
    }

    public async Task<ProductResponse> DeleteAsync(int productId)
    {
        var existingProduct = await _productRepository.FindByIdAsync(productId);
        
        // Validate Tutorial

        if (existingProduct == null)
            return new ProductResponse("Product not found.");
        
        try
        {
            _productRepository.Remove(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new ProductResponse($"An error occurred while deleting the product: {e.Message}");
        }
    }
}