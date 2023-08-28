using FluentValidation;
using NeedleWork.Application.Features.Suppliers.Commands.UpdateName;

namespace NeedleWork.Application.Validators.Suppliers;

public class UpdateSupplierContactCommandValidator : AbstractValidator<UpdateSupplierContactCommand>
{
    public UpdateSupplierContactCommandValidator()
    {
        RuleFor(x => x.NewContact)
            .NotEmpty()
            .WithMessage("New contact must be informed")
            .MinimumLength(3)
            .WithMessage("New contact must have at least 3 characters");
    }
}