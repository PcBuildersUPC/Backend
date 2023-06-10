using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PcBuilders.Learning.Domain.Model;
using PcBuilders.Learning.Domain.Services;
using PcBuilders.Learning.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PcBuilders.Learning.Controllers;

[ApiController]
[Route("/api/v1/stores/{storeId}/products")]
public class StoreProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public StoreProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Products for given Store",
        Description = "Get existing Products associated with the specified Store",
        OperationId = "GetStoreProducts",
        Tags = new[] { "Stores"}
    )]
    public async Task<IEnumerable<ProductResource>> GetAllByCategoryIdAsync(int storeId)
    {
        var products = await _productService.ListByStoreIdAsync(storeId);

        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

        return resources;
    }
}