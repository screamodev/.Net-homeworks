using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
{
    private readonly ICatalogTypeRepository _catalogTypeRepository;
    private readonly IMapper _mapper;

    public CatalogTypeService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogTypeRepository catalogTypeRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogTypeRepository = catalogTypeRepository;
        _mapper = mapper;
    }

    public async Task<List<CatalogTypeDto>> GetTypesAsync()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogTypeRepository.GetAllAsync();
            var typeDtos = result.Select(s => _mapper.Map<CatalogTypeDto>(s)).ToList();

            return typeDtos;
        });
    }

    public async Task<CatalogTypeDto> AddTypeAsync(CatalogTypeCreateDto catalogType)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var item = await _catalogTypeRepository.AddAsync(catalogType);

            return new CatalogTypeDto()
            {
                Id = item.Id,
                Type = item.Type
            };
        });
    }

    public async Task<CatalogTypeDto?> UpdateTypeAsync(int id, CatalogTypeUpdateDto catalogType)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var item = await _catalogTypeRepository.UpdateAsync(id, catalogType);

            if (item == null)
            {
                return null;
            }

            return new CatalogTypeDto()
            {
                Id = item.Id,
                Type = item.Type
            };
        });
    }

    public async Task<bool?> DeleteTypeAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var isDeleted = await _catalogTypeRepository.DeleteAsync(id);

            return isDeleted;
        });
    }
}