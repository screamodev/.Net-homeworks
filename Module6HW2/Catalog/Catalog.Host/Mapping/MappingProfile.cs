using AutoMapper;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItem, CatalogItemDto>()
            .ForMember("PictureUrl", opt
                => opt.MapFrom<CatalogItemPictureResolver, string>(c => c.PictureFileName));
        CreateMap<CatalogBrand, CatalogBrandDto>();
        CreateMap<CatalogBrandCreateDto, CatalogBrand>();
        CreateMap<CatalogBrandUpdateDto, CatalogBrand>();
        CreateMap<CatalogType, CatalogTypeDto>();
        CreateMap<CatalogTypeCreateDto, CatalogType>();
        CreateMap<CatalogTypeUpdateDto, CatalogType>();
    }
}