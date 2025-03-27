using NetShop.OrderService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetShop.OrderService.Application.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }
}
