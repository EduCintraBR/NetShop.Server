using MediatR;
using NetShop.OrderService.Application.Dtos;

namespace NetShop.OrderService.Application.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
