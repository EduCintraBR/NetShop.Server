using MediatR;
using NetShop.OrderService.Application.DTOs;

namespace NetShop.OrderService.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public Guid Id { get; set; }
    }
}
