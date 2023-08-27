using FluentValidation;
using NeedleWork.Application.Features.Suppliers.Commands.Create;

namespace NeedleWork.Application.Validators.Suppliers;

public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
{
    public CreateSupplierCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name must be informed")
            .MinimumLength(3)
            .WithMessage("Name must have at least 3 characters");

        RuleFor(x => x.Contact)
            .NotEmpty()
            .WithMessage("Contact must be informed")
            .MinimumLength(3)
            .WithMessage("Contact must have at least 3 characters");            
    }
}