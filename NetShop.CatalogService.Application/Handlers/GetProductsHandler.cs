using AutoMapper;
using MediatR;
using NetShop.CatalogService.Application.DTOs;
using NetShop.CatalogService.Application.Queries;
using NetShop.CatalogService.Infrastructure.Persistence.Repositories;

namespace NetShop.CatalogService.Application.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductsHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
