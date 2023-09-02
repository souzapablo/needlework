using MediatR;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Repositories;
using NeedleWork.Core.Shared;

namespace NeedleWork.Application.Features.Users.Commands.Delete;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
            throw new NotFoundException(Errors.UserNotFound(request.Id));
        
        user.Delete();

        await _userRepository.UpdateAsync(user);

        return Unit.Value;
    }
}