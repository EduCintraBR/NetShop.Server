using Microsoft.EntityFrameworkCore;
using NetShop.OrderService.Application.Interfaces;
using NetShop.OrderService.Domain.Entities;
using NetShop.OrderService.Infrastructure.Persistence.Data;

namespace NetShop.OrderService.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> FindByIdAsync(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }
    }
}
