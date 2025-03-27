using AutoMapper;
using MediatR;
using NetShop.OrderService.Application.DTOs;
using NetShop.OrderService.Application.Interfaces;
using NetShop.OrderService.Application.Queries;

namespace NetShop.OrderService.Application.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetOrdersHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }
    }
}
