using FluentValidation;
using NetShop.OrderService.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetShop.OrderService.Application.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("O ID do cliente é obrigatório.");
            RuleFor(x => x.OrderItems)
                .NotEmpty().WithMessage("Pelo menos um item de pedido deve ser informado.");

            RuleForEach(x => x.OrderItems).SetValidator(new OrderItemDtoValidator());
        }
    }
}
