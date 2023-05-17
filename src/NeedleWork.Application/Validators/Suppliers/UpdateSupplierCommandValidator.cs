using FluentValidation;
using NeedleWork.Application.Features.Suppliers.Commands.Update;

namespace NeedleWork.Application.Validators.Suppliers;

public class UpdateSupplierCommandValidator : AbstractValidator<UpdateSupplierCommand>
{
    public UpdateSupplierCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Invalid id");

        RuleFor(c => c.Contact)
            .MinimumLength(5)
            .WithMessage("Contact must have at least 5 characters");

        RuleFor(c => c.Name)
            .MinimumLength(5)
            .WithMessage("Name must have at least 3 characters");
    }
}
