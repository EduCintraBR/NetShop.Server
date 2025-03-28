using AutoMapper;
using Moq;
using NetShop.OrderService.Application.Dtos;
using NetShop.OrderService.Application.DTOs;
using NetShop.OrderService.Application.Handlers;
using NetShop.OrderService.Application.Interfaces;
using NetShop.OrderService.Application.Queries;
using NetShop.OrderService.Domain.Entities;

namespace NetShop.OrderService.Tests.Handlers
{
    public class GetOrdersHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsMappedOrders()
        {
            // Arrange
            var mockRepository = new Mock<IOrderRepository>();
            var mockMapper = new Mock<IMapper>();

            var orders = new List<Order>
            {
                new Order 
                { 
                    Id = Guid.NewGuid(), 
                    CustomerId = Guid.NewGuid(), 
                    OrderDate = DateTime.UtcNow, 
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem 
                        { 
                            Id = Guid.NewGuid(), 
                            ProductId = Guid.NewGuid(), 
                            Quantity = 3, 
                            UnitPrice = 20 
                        }
                    }
                },
                new Order 
                { 
                    Id = Guid.NewGuid(), 
                    CustomerId = Guid.NewGuid(), 
                    OrderDate = DateTime.UtcNow, 
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem { 
                            Id = Guid.NewGuid(), 
                            ProductId = Guid.NewGuid(), 
                            Quantity = 1, 
                            UnitPrice = 50 
                        }
                    }
                }
            };

            mockRepository.Setup(r => r.GetAllAsync())
                          .ReturnsAsync(orders);

            // Simula o mapeamento para DTOs
            var dtos = orders.Select(o => new OrderDto
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                OrderDate = o.OrderDate,
                OrderItems = o.OrderItems.Select(i => new OrderItemDto
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                })
            });

            mockMapper.Setup(m => m.Map<IEnumerable<OrderDto>>(orders))
                      .Returns(dtos);

            var handler = new GetOrdersHandler(mockRepository.Object, mockMapper.Object);

            // Act
            var result = await handler.Handle(new GetOrdersQuery(), CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, dto => dto.OrderItems.Any(i => i.Quantity == 3));
        }
    }
}
