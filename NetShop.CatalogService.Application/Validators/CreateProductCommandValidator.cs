using FluentValidation;
using NetShop.CatalogService.Application.Commands;

namespace NetShop.CatalogService.Application.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome do produto é obrigatório.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("O preço deve ser maior que zero.");
        }
    }
}
