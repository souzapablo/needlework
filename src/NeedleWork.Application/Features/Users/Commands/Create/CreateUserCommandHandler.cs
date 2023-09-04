using MediatR;
using NeedleWork.Application.Abstractions;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Application.Features.Users.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        bool isEmailRegistered = await _userRepository.IsEmailRegistered(request.Email);

        if (isEmailRegistered)
            throw new EmailAlreadyRegisteredException();
        
        string hashPassword = _authService.HashPassword(request.Password);

        User user = new(request.FirstName, request.LastName, request.Email, hashPassword, request.BirthDate);

        await _userRepository.CreateAsync(user);

        return user.Id;
    }
}