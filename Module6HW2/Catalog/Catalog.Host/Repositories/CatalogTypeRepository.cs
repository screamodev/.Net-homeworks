using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogTypeRepository : ICatalogTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CatalogTypeRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<List<CatalogType>> GetAllAsync()
    {
        var items = await _dbContext.CatalogTypes
            .OrderBy(c => c.Type)
            .ToListAsync();

        return items;
    }

    public async Task<CatalogType?> GetByIdAsync(int id)
    {
        var item = await _dbContext.CatalogTypes
            .FindAsync(id);

        return item;
    }

    public async Task<CatalogType> AddAsync(CatalogTypeCreateDto catalogType)
    {
        var item = await _dbContext.CatalogTypes.AddAsync(
            new CatalogType()
            {
                Type = catalogType.Type
            });

        await _dbContext.SaveChangesAsync();

        return item.Entity;
    }

    public async Task<CatalogType?> UpdateAsync(int id, CatalogTypeUpdateDto catalogType)
    {
        var item = await GetByIdAsync(id);

        if (item == null)
        {
            return null;
        }

        item.Type = catalogType.Type;

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

        await _dbContext.SaveChangesAsync();

        return true;
    }
}