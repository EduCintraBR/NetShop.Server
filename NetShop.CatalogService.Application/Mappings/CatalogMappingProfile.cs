using AutoMapper;
using NetShop.CatalogService.Application.Commands;
using NetShop.CatalogService.Application.DTOs;
using NetShop.CatalogService.Domain.Entities;

namespace NetShop.CatalogService.Application.Mappings
{
    public class CatalogMappingProfile : Profile
    {
        public CatalogMappingProfile()
        {
            CreateMap<CreateProductCommand, Product>();

            CreateMap<Product, ProductDto>();
        }
    }
}
