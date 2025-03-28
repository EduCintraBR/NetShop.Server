using AutoMapper;
using Moq;
using NetShop.CatalogService.Application.Commands;
using NetShop.CatalogService.Application.Handlers;
using NetShop.CatalogService.Domain.Entities;
using NetShop.CatalogService.Domain.Events;
using NetShop.CatalogService.Infrastructure.Messaging;
using NetShop.CatalogService.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetShop.CatalogService.Tests.Handlers
{
    public class CreateProductHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_AddsProductAndPublishesEvent()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockEventPublisher = new Mock<IEventPublisher>();

            var command = new CreateProductCommand
            {
                Name = "Test Product",
                Description = "Test Description",
                Price = 100,
                CategoryId = Guid.NewGuid()
            };

            // Simula o mapeamento do comando para a entidade Product
            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                CategoryId = Guid.NewGuid()
            };
            mockMapper.Setup(m => m.Map<Product>(command))
                .Returns(product);

            var handler = new CreateProductHandler(mockRepository.Object, mockMapper.Object, mockEventPublisher.Object);
            
            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            // Verifica se o repositório recebeu a chamada para adicionar o produto
            mockRepository.Verify(r => r.AddAsync(It.Is<Product>(p => p.Name == command.Name)), Times.Once);

            // Verifica se o event publisher foi chamado com um evento contendo as informações do produto
            mockEventPublisher.Verify(ep => ep.PublishAsync(It.Is<ProductCreatedEvent>(e =>
                e.ProductId == product.Id && e.Name == command.Name)), Times.Once);

            // Valida se o resultado é um Guid (diferente de Guid.Empty)
            Assert.NotEqual(Guid.Empty, result);
        }
    }
}
