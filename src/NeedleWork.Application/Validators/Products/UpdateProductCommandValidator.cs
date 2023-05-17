using FluentValidation;
using NeedleWork.Application.Features.Products.Commands.Update;

namespace NeedleWork.Application.Validators.Products;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(c => c.Id)
            .GreaterThan(0)
            .WithMessage("Invalid id");

        RuleFor(c => c.Description)
            .MinimumLength(2)
            .WithMessage("Description must have at least 2 characters");

        RuleFor(c => c.Price)
            .GreaterThan(0)
            .WithMessage("Invalid price");
    }
}
