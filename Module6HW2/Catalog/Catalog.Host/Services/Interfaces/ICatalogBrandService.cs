using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogBrandService
{
    Task<List<CatalogBrandDto>> GetBrandsAsync();
    Task<CatalogBrandDto> AddBrandAsync(CatalogBrandCreateDto catalogBrand);
    Task<CatalogBrandDto?> UpdateBrandAsync(int id, CatalogBrandUpdateDto catalogBrand);
    Task<bool?> DeleteBrandAsync(int id);
}