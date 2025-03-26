namespace NetShop.CatalogService.Domain.Events
{
    public class ProductCreatedEvent
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }
    }
}
