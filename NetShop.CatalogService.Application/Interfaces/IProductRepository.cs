using NetShop.CatalogService.Domain.Entities;

namespace NetShop.CatalogService.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);
    }
}
