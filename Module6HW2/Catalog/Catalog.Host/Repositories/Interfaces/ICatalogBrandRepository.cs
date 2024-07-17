using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogBrandRepository
{
    Task<List<CatalogBrand>> GetAllAsync();
    Task<CatalogBrand?> GetByIdAsync(int id);
    Task<CatalogBrand> AddAsync(CatalogBrandCreateDto catalogBrand);
    Task<CatalogBrand?> UpdateAsync(int id, CatalogBrandUpdateDto catalogBrand);
    Task<bool?> DeleteAsync(int id);
}