using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogBrandRepository : ICatalogBrandRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogBrandRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<List<CatalogBrand>> GetAllAsync()
    {
        var items = await _dbContext.CatalogBrands
            .OrderBy(c => c.Brand)
            .ToListAsync();

        return items;
    }

    public async Task<CatalogBrand?> GetByIdAsync(int id)
    {
        var item = await _dbContext.CatalogBrands
            .FindAsync(id);

        return item;
    }

    public async Task<CatalogBrand> AddAsync(CatalogBrandCreateDto catalogBrand)
    {
        var item = await _dbContext.CatalogBrands.AddAsync(
        new CatalogBrand()
        {
            Brand = catalogBrand.Brand
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity;
    }

    public async Task<CatalogBrand?> UpdateAsync(int id, CatalogBrandUpdateDto catalogBrand)
    {
        var item = await GetByIdAsync(id);

        if (item == null)
        {
            return null;
        }

        item.Brand = catalogBrand.Brand;

        await _dbContext.SaveChangesAsync();

        return item;
    }

    public async Task<bool?> DeleteAsync(int id)
    {
        var item = await GetByIdAsync(id);

        if (item == null)
        {
            return null;
        }

        _dbContext.Remove(item);

        return true;
    }
}