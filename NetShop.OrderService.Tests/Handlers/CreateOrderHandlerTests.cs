using Moq;
using NetShop.OrderService.Application.Commands;
using NetShop.OrderService.Application.Dtos;
using NetShop.OrderService.Application.Handlers;
using NetShop.OrderService.Application.Interfaces;
using NetShop.OrderService.Domain.Entities;

namespace NetShop.OrderService.Tests.Handlers
{
    public class CreateOrderHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_AddsOrderAndReturnsOrderId()
        {
            // Arrange
            var mockRepository = new Mock<IOrderRepository>();

            var command = new CreateOrderCommand
            {
                CustomerId = Guid.NewGuid(),
                OrderItems = new System.Collections.Generic.List<OrderItemDto>
                {
                    new OrderItemDto { ProductId = Guid.NewGuid(), Quantity = 2 },
                    new OrderItemDto { ProductId = Guid.NewGuid(), Quantity = 1 }
                }
            };

            var handler = new CreateOrderHandler(mockRepository.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            mockRepository.Verify(r => r.AddAsync(It.Is<Order>(o =>
                o.CustomerId == command.CustomerId &&
                o.OrderItems.Count == command.OrderItems.Count)), Times.Once);

            Assert.NotEqual(Guid.Empty, result);
        }
    }
}
