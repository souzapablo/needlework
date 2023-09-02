using MediatR;

namespace NeedleWork.Application.Features.Users.Commands.Delete;

public record DeleteUserCommand(long Id) : IRequest<Unit>;