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
[SwaggerTag("Create, read, update and delete Stores")]
public class StoresController : ControllerBase
{
    private readonly IStoreService _storeService;
    private readonly IMapper _mapper;
    
    
    public StoresController(IStoreService storeService, IMapper mapper)
    {
        _storeService = storeService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<StoreResource>), 200)]
    public async Task<IEnumerable<StoreResource>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<Store>, 
            IEnumerable<StoreResource>>(await _storeService.ListAsync());
    }

    [HttpPost]
    [ProducesResponseType(typeof(StoreResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] SaveStoreResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var storeModel = _mapper.Map<SaveStoreResource, Store>(resource);

        var storeResponse = await _storeService.SaveAsync(storeModel);

        if (!storeResponse.Success)
            return BadRequest(storeResponse.Message);

        var storeResource = _mapper.Map<Store, StoreResource>(storeResponse.Model);

        //return Ok(categoryResource);
        return Created(nameof(PostAsync), storeResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveStoreResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var storeModel = _mapper.Map<SaveStoreResource, Store>(resource);
        var storeResponse = await _storeService.UpdateAsync(id, storeModel);
        
        if (!storeResponse.Success)
            return BadRequest(storeResponse.Message);

        var storeResource = _mapper.Map<Store, StoreResource>(storeResponse.Model);

        return Ok(storeResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var storeResponse = await _storeService.DeleteAsync(id);

        if (!storeResponse.Success)
            return BadRequest(storeResponse.Message);
        
        var storeResource = _mapper.Map<Store, StoreResource>(storeResponse.Model);

        return Ok(storeResource);
    }
}

