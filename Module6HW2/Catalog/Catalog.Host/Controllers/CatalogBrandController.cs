using System.Net;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBrandController : ControllerBase
{
    private readonly ICatalogBrandService _catalogBrandService;

    public CatalogBrandController(ICatalogBrandService catalogBrandService)
    {
        _catalogBrandService = catalogBrandService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogBrandDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add([FromQuery] CatalogBrandCreateDto catalogBrand)
    {
        var result = await _catalogBrandService.AddBrandAsync(catalogBrand);

        if (result == null)
        {
           return StatusCode(500, "Data wasn't added");
        }

        return Ok(result);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(CatalogBrandDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update([FromQuery] CatalogBrandUpdateDto catalogBrand, [FromRoute] int id)
    {
        var result = await _catalogBrandService.UpdateBrandAsync(id, catalogBrand);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _catalogBrandService.DeleteBrandAsync(id);

        if (result == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}