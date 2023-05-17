using FluentValidation;
using NeedleWork.Application.Features.Users.Commands.Create;
using System.Text.RegularExpressions;

namespace NeedleWork.Application.Validators.Users;

public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
{
	public CreateUserCommandValidation()
	{
		RuleFor(c => c.Email)
			.EmailAddress()
			.WithMessage("Invalid e-mail address");

		RuleFor(c => c.Password)
			.Must(ValidPassword)
			.WithMessage("Password must have at least eight characters, one letter and one number");

		RuleFor(c => c.Username)
			.MinimumLength(5)
			.WithMessage("Username must have at least five characters");
	}

	private static bool ValidPassword(string password)
	{
		var regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

		return regex.IsMatch(password);
	}
}
