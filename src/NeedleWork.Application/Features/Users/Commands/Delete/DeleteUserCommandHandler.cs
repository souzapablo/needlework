using MediatR;
using NeedleWork.Core.Repositories;

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
        var user = await _userRepository.GetByIdAsync(request.Id) ?? throw new Exception("User not found");

        user.Delete();

        await _userRepository.UpdateAsync(user);

        return Unit.Value;
    }
}
