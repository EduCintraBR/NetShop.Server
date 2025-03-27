using MediatR;
using NetShop.CatalogService.Application.DTOs;

namespace NetShop.CatalogService.Application.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductDto>> { }
}
