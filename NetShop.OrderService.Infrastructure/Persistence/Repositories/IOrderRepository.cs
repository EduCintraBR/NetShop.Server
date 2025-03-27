using NetShop.OrderService.Domain.Entities;

namespace NetShop.OrderService.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> FindByIdAsync(Guid id);
    }
}
