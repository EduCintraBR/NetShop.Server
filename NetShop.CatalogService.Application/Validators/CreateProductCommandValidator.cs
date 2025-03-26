using FluentValidation;
using NetShop.CatalogService.Application.Commands;

namespace NetShop.CatalogService.Application.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("A descrição do produto é obrigatória.")
                .MaximumLength(1000).WithMessage("A descrição do produto deve ter no máximo 1000 caracteres.");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("A categoria é obrigatória.");
        }
    }
}
