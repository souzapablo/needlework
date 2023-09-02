using System.Text.RegularExpressions;
using FluentValidation;
using NeedleWork.Application.Features.Users.Commands.Create;

namespace NeedleWork.Application.Validators.Users;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name must be informed");   

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name must be informed");       

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Invalid e-mail format");

        RuleFor(x => x.Password)
            .Must(IsPasswordValid)
            .WithMessage("Password must have at least eight characters, at least one upper case letter, one lower case letter, one number and one special character");   

        RuleFor(x => x.BirthDate)
            .Must(IsDateValid)
            .WithMessage("User must have at least 16 years");    
    }   

    private bool IsDateValid(DateOnly date)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);

        int ageInYears = today.Year - date.Year;
        bool hasMonthPast = today.Month < date.Month;
        bool hasBirthdayPast = today.Month == date.Month && today.Day < date.Day;

        if (hasMonthPast || hasBirthdayPast)
            ageInYears--;

        return ageInYears >= 16;
    }

    private bool IsPasswordValid(string password)
    {
        string pattern = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$";
        return Regex.Match(password, pattern).Success;
    }
}