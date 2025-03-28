using System.Text.Json;

namespace NetShop.CatalogService.Infrastructure.Messaging
{
    public class SimpleEventPublisher : IEventPublisher
    {
        public Task PublishAsync<T>(T @event)
        {
            Console.WriteLine($"Evento publicado: {JsonSerializer.Serialize(@event)}");
            return Task.CompletedTask;
        }
    }
}
