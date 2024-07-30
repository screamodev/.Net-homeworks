using System.Text.Json;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ICatalogService _catalogService;
    private readonly ICatalogBrandService _catalogBrandService;
    private readonly ICatalogTypeService _catalogTypeService;

    public CatalogBffController(
        ICatalogService catalogService,
        ICatalogBrandService catalogBrandService,
        ICatalogTypeService catalogTypeService)
    {
        _catalogService = catalogService;
        _catalogBrandService = catalogBrandService;
        _catalogTypeService = catalogTypeService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsWithFiltersRequest<CatalogFilter> request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(request.PageIndex, request.PageSize, request.Filters);

        Console.WriteLine("234 " + JsonSerializer.Serialize(result));

        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<CatalogBrandDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Brands()
    {
        var result = await _catalogBrandService.GetBrandsAsync();
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<CatalogTypeDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Types()
    {
        var result = await _catalogTypeService.GetTypesAsync();
        return Ok(result);
    }
}