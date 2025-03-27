using MediatR;
using NetShop.CatalogService.Application.DTOs;

namespace NetShop.CatalogService.Application.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto> 
    {
        public Guid Id { get; set; }
    }
}
