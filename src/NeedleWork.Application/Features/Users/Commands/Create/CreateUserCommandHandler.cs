using MediatR;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Application.Features.Users.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        bool isEmailRegistered = await _userRepository.IsEmailRegistered(request.Email);

        if (isEmailRegistered)
            throw new EmailAlreadyRegisteredException();

        User user = new(request.FirstName, request.LastName, request.Email, request.Password, request.BirthDate);

        await _userRepository.CreateAsync(user);

        return user.Id;
    }
}