﻿using MVC.Dtos;
using MVC.Models.Enums;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services;

public class CatalogService : ICatalogService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;
    private readonly ILogger<CatalogService> _logger;

    public CatalogService(IHttpClientService httpClient, ILogger<CatalogService> logger, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
        _logger = logger;
    }

    public async Task<Catalog> GetCatalogItems(int page, int take, int? brand, int? type)
    {
        var filters = new Dictionary<CatalogTypeFilter, int>();

        if (brand.HasValue)
        {
            filters.Add(CatalogTypeFilter.BrandId, brand.Value);
        }
        
        if (type.HasValue)
        {
            filters.Add(CatalogTypeFilter.TypeId, type.Value);
        }
        
        var result = await _httpClient.SendAsync<Catalog, PaginatedItemsRequest<CatalogTypeFilter>>($"{_settings.Value.CatalogUrl}/items",
           HttpMethod.Post, 
           new PaginatedItemsRequest<CatalogTypeFilter>()
            {
                PageIndex = page,
                PageSize = take,
                Filters = filters
            });

        return result;
    }

    public async Task<IEnumerable<SelectListItem>> GetBrands()
    {
        var brands = await _httpClient.SendAsync<List<CatalogBrand>, object>($"{_settings.Value.CatalogUrl}/brands", HttpMethod.Get);
        
        var selectList = new List<SelectListItem>
        {
            new SelectListItem
            {
                Value = "",
                Text = "None"
            }
        };
        
        selectList.AddRange(brands.Select(brand => new SelectListItem
        {
            Value = brand.Id.ToString(),
            Text = brand.Brand
        }));
        
        return selectList;
    }

    public async Task<IEnumerable<SelectListItem>> GetTypes()
    {
        var types = await _httpClient.SendAsync<List<CatalogType>, object>($"{_settings.Value.CatalogUrl}/types", HttpMethod.Get);
        
        var selectList = new List<SelectListItem>
        {
            new SelectListItem
            {
                Value = "",
                Text = "None"
            }
        };
        
        selectList.AddRange(types.Select(type => new SelectListItem
        {
            Value = type.Id.ToString(),
            Text = type.Type
        }));
        
        return selectList;
    }
}
