using AutoMapper;
using MediatR;
using NetShop.OrderService.Application.DTOs;
using NetShop.OrderService.Application.Interfaces;
using NetShop.OrderService.Application.Queries;

namespace NetShop.OrderService.Application.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _repository.FindByIdAsync(request.Id);

            if(order == null)
            {
                throw new Exception("Id do pedido não encontrado.");
            }

            return _mapper.Map<OrderDto>(order);
        }
    }
}
