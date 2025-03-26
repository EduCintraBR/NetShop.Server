using AutoMapper;
using MassTransit;
using MediatR;
using NetShop.CatalogService.Application.Commands;
using NetShop.CatalogService.Application.Interfaces;
using NetShop.CatalogService.Domain.Entities;
using NetShop.CatalogService.Domain.Events;

namespace NetShop.CatalogService.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateProductHandler(IProductRepository repository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _repository = repository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            product.Id = Guid.NewGuid();

            await _repository.AddAsync(product);

            await _publishEndpoint.Publish(new ProductCreatedEvent
            {
                ProductId = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price
            });

            return product.Id;
        }
    }
}
