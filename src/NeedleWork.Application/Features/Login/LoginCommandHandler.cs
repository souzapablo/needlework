using MediatR;
using NeedleWork.Application.Abstractions;
using NeedleWork.Application.Models.Users;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Application.Features.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IAuthService _authService;
    public LoginCommandHandler(
        IUserRepository userRepository, 
        IJwtProvider jwtProvider,
        IAuthService authService)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _authService = authService; 
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        string hasPassword = _authService.HashPassword(request.Password);

        UserLoginDTO? user = await _userRepository.GetByEmailAndPasswordAsync(request.Email, hasPassword);

        if (user is null)
            throw new InvalidCredentialsException();
    
        string token = _jwtProvider.Generate(user);

        return token;
    }
}