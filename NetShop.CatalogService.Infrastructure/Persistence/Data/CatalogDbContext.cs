using Microsoft.EntityFrameworkCore;
using NetShop.CatalogService.Domain.Entities;

namespace NetShop.CatalogService.Infrastructure.Persistence.Data
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
