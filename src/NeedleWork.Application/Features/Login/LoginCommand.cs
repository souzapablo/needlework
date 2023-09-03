using MediatR;

namespace NeedleWork.Application.Features.Login;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<string>;