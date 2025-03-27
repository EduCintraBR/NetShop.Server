using NetShop.CatalogService.Domain.Entities;

namespace NetShop.CatalogService.Infrastructure.Persistence.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> FindByIdAsync(Guid id);
    }
}
