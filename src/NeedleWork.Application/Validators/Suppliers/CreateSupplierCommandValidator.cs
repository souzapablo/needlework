using FluentValidation;
using NeedleWork.Application.Features.Suppliers.Commands.Create;

namespace NeedleWork.Application.Validators.Suppliers;

public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
{
    public CreateSupplierCommandValidator()
    {
        RuleFor(c => c.Contact)
            .MinimumLength(5)
            .WithMessage("Contact must have at least 5 characters");

        RuleFor(c => c.Name)
            .MinimumLength(5)
            .WithMessage("Name must have at least 5 characters");
    }
}
