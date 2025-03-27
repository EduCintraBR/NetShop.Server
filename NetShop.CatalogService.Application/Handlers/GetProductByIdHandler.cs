using AutoMapper;
using MediatR;
using NetShop.CatalogService.Application.DTOs;
using NetShop.CatalogService.Application.Queries;
using NetShop.CatalogService.Infrastructure.Persistence.Repositories;

namespace NetShop.CatalogService.Application.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.FindByIdAsync(request.Id);

            if (product == null)
            {
                throw new Exception("Id do produto não encontrado.");
            }

            return _mapper.Map<ProductDto>(product);
        }
    }
}
