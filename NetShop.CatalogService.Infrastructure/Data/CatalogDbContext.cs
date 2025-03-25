using Microsoft.EntityFrameworkCore;
using NetShop.CatalogService.Domain.Entities;

namespace NetShop.CatalogService.Infrastructure.Data
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) {}
        public DbSet<Product> Products { get; set; }
    }
}
