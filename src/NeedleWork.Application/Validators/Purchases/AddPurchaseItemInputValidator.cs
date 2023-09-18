using FluentValidation;
using NeedleWork.Application.InputModels.Purchases;

namespace NeedleWork.Application.Validators.Purchases;

public class AddPurchaseItemInputValidator : AbstractValidator<AddPurchaseItemInputModel>
{
    public AddPurchaseItemInputValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("Invalid product id");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Invalid quantity");
    }
}