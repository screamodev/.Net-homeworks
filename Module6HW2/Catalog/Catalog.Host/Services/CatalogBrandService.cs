using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
{
    private readonly ICatalogBrandRepository _catalogBrandRepository;
    private readonly IMapper _mapper;

    public CatalogBrandService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogBrandRepository catalogBrandRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogBrandRepository = catalogBrandRepository;
        _mapper = mapper;
    }

    public async Task<List<CatalogBrandDto>> GetBrandsAsync()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogBrandRepository.GetAllAsync();
            var resultBrandDtos = result.Select(s => _mapper.Map<CatalogBrandDto>(s)).ToList();

            return resultBrandDtos;
        });
    }

    public async Task<CatalogBrandDto> AddBrandAsync(CatalogBrandCreateDto catalogBrand)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var item = await _catalogBrandRepository.AddAsync(catalogBrand);

            return new CatalogBrandDto()
            {
                Id = item.Id,
                Brand = item.Brand
            };
        });
    }

    public async Task<CatalogBrandDto?> UpdateBrandAsync(int id, CatalogBrandUpdateDto catalogBrand)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var item = await _catalogBrandRepository.UpdateAsync(id, catalogBrand);

            if (item == null)
            {
                return null;
            }

            return new CatalogBrandDto()
            {
                Id = item.Id,
                Brand = item.Brand
            };
        });
    }

    public async Task<bool?> DeleteBrandAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var isDeleted = await _catalogBrandRepository.DeleteAsync(id);

            if (isDeleted == false)
            {
                throw new Exception("Item wasn't deleted");
            }

            return isDeleted;
        });
    }
}