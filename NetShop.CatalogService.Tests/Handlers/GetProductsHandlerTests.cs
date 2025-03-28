using AutoMapper;
using Moq;
using NetShop.CatalogService.Application.DTOs;
using NetShop.CatalogService.Application.Handlers;
using NetShop.CatalogService.Application.Queries;
using NetShop.CatalogService.Domain.Entities;
using NetShop.CatalogService.Infrastructure.Persistence.Repositories;

namespace NetShop.CatalogService.Tests.Handlers
{
    public class GetProductsHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsMappedProducts()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var mockMapper = new Mock<IMapper>();

            // Lista de produtos simulada
            var products = new List<Product>
            {
                new Product { Id = Guid.NewGuid(), Name = "Prod 1", Price = 50, CategoryId = Guid.NewGuid() },
                new Product { Id = Guid.NewGuid(), Name = "Prod 2", Price = 150, CategoryId = Guid.NewGuid() }
            };

            // Configura o repositório para retornar a lista de produtos
            mockRepository.Setup(r => r.GetAllAsync())
                          .ReturnsAsync(products);

            // Simula o mapeamento dos produtos para DTOs
            var dtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId
            });

            mockMapper.Setup(m => m.Map<IEnumerable<ProductDto>>(products))
                      .Returns(dtos);

            var handler = new GetProductsHandler(mockRepository.Object, mockMapper.Object);

            // Act
            var result = await handler.Handle(new GetProductsQuery(), CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, dto => dto.Name == "Prod 1");
            Assert.Contains(result, dto => dto.Name == "Prod 2");
        }
    }
}
