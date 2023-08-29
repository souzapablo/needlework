using FluentValidation;
using NeedleWork.Application.Features.Products.Create;

namespace NeedleWork.Application.Validators.Products;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.SupplierId)
            .GreaterThan(0)
            .WithMessage("Invalid supplier id");

        RuleFor(x => x.Description)
            .MinimumLength(3)
            .WithMessage("Product description must have at least 3 characters");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Invalid price");

        RuleFor(x => x.UnitOfMeasurement)
            .IsInEnum()
            .WithMessage("Invalid unit of measurement");   
    }
}