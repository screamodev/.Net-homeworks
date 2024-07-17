using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogTypeRepository
{
    Task<List<CatalogType>> GetAllAsync();
    Task<CatalogType?> GetByIdAsync(int id);
    Task<CatalogType> AddAsync(CatalogTypeCreateDto catalogType);
    Task<CatalogType?> UpdateAsync(int id, CatalogTypeUpdateDto catalogType);
    Task<bool?> DeleteAsync(int id);
}