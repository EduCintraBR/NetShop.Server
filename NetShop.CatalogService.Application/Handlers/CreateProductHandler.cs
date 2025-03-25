using MediatR;
using NetShop.CatalogService.Application.Commands;
using NetShop.CatalogService.Domain.Entities;
using NetShop.CatalogService.Infrastructure.Data;

namespace NetShop.CatalogService.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly CatalogDbContext _context;
        public CreateProductHandler(CatalogDbContext context) => _context = context;

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
