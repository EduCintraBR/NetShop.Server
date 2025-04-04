﻿using AutoMapper;
using MediatR;
using NetShop.OrderService.Application.Commands;
using NetShop.OrderService.Application.Interfaces;
using NetShop.OrderService.Domain.Entities;

namespace NetShop.OrderService.Application.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = request.CustomerId,
                OrderDate = DateTime.UtcNow,
                OrderItems = request.OrderItems.Select(item => new OrderItem
                {
                    Id = Guid.NewGuid(),
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = 0
                })
                .ToList()
            };

            await _orderRepository.AddAsync(order);
            return order.Id;
        }
    }
}
