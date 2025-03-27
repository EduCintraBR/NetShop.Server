using AutoMapper;
using NetShop.OrderService.Application.Commands;
using NetShop.OrderService.Application.Dtos;
using NetShop.OrderService.Application.DTOs;
using NetShop.OrderService.Domain.Entities;

namespace NetShop.OrderService.Application.Mappings
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<CreateOrderCommand, Order>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDate, opt => opt.Ignore())
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

            CreateMap<OrderItemDto, OrderItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UnitPrice, opt => opt.Ignore());

            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
