using FluentValidation;
using NeedleWork.Application.Features.Products.Commands.Create;

namespace NeedleWork.Application.Validators.Products;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(c => c.SupplierId)
            .GreaterThan(0)
            .WithMessage("Invalid supplier id");

        RuleFor(c => c.Description)
            .MinimumLength(5)
            .WithMessage("Description must have at least 5 characters");

        RuleFor(c => c.Price)
            .GreaterThan(0)
            .WithMessage("Invalid price");
    }
}
