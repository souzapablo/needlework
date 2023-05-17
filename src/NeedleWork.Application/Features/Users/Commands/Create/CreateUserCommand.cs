using MediatR;

namespace NeedleWork.Application.Features.Users.Commands.Create;

public record CreateUserCommand(
    string Email,
    string Username,
    string Password) : IRequest<long>;
