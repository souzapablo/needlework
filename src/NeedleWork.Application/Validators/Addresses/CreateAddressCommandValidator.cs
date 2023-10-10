using System.Text.RegularExpressions;
using FluentValidation;
using NeedleWork.Application.Features.Addresses;

namespace NeedleWork.Application.Validators.Addresses;

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("Invalid user id");

        RuleFor(x => x.Cep)
            .Must(IsValidCep)
            .WithMessage("Invalid cep");

        RuleFor(x => x.Number)
            .GreaterThan(0)
            .WithMessage("Invalid number");   
        
        When(x => x.Complement is not null, () => 
        {
            RuleFor(x => x.Complement)
                .MinimumLength(3)
                .WithMessage("Complemente must have at least 3 characaters");
        });
            
    }

    private bool IsValidCep(string cep)
    {
        string pattern = @"\d{5}-\d{3}";
        return Regex.Match(cep, pattern).Success;
    }
}