using MediatR;
using NetShop.OrderService.Application.DTOs;

namespace NetShop.OrderService.Application.Queries
{
    public class GetOrdersQuery : IRequest<IEnumerable<OrderDto>> { }
}
