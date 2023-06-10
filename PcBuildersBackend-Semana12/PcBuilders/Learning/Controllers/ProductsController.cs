using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PcBuilders.Learning.Domain.Model;
using PcBuilders.Learning.Domain.Services;
using PcBuilders.Learning.Resources;
using PcBuilders.Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace PcBuilders.Learning.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    
    
    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductResource>), 200)]
    public async Task<IEnumerable<ProductResource>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<Product>, 
            IEnumerable<ProductResource>>(await _productService.ListAsync());
    }

    [HttpPost]
    [ProducesResponseType(typeof(ProductResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var productModel = _mapper.Map<SaveProductResource, Product>(resource);

        var productReponse = await _productService.SaveAsync(productModel);

        if (!productReponse.Success)
            return BadRequest(productReponse.Message);

        var productResource = _mapper.Map<Product, ProductResource>(productReponse.Model);

        //return Ok(categoryResource);
        return Created(nameof(PostAsync), productResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var productModel = _mapper.Map<SaveProductResource, Product>(resource);
        var productReponse = await _productService.UpdateAsync(id, productModel);
        
        if (!productReponse.Success)
            return BadRequest(productReponse.Message);

        var productResource = _mapper.Map<Product, ProductResource>(productReponse.Model);

        return Ok(productResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var productReponse = await _productService.DeleteAsync(id);

        if (!productReponse.Success)
            return BadRequest(productReponse.Message);
        
        var productResource = _mapper.Map<Product, ProductResource>(productReponse.Model);

        return Ok(productResource);
    }
}

