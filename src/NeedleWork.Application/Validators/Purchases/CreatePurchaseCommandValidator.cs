using FluentValidation;
using NeedleWork.Application.Features.Purchases.Commands.Create;

namespace NeedleWork.Application.Validators.Purchases;

public class CreatePurchaseCommandValidator : AbstractValidator<CreatePurchaseCommand>
{
    public CreatePurchaseCommandValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("Invalid product id");

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("Invalid user id");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Invalid quantity");

        RuleFor(x => x.PurchaseDate)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Invalid purchase date");
    }
}