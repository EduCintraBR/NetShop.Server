using NetShop.OrderService.Domain.Entities;

namespace NetShop.OrderService.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> AddAsync(Order order);
    }
}
