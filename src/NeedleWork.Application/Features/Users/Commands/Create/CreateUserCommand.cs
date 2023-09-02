using MediatR;

namespace NeedleWork.Application.Features.Users.Commands.Create;

public record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    DateOnly BirthDate
) : IRequest<long>;