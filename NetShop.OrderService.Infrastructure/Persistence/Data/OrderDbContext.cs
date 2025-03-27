using Microsoft.EntityFrameworkCore;
using NetShop.OrderService.Domain.Entities;

namespace NetShop.OrderService.Infrastructure.Persistence.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
