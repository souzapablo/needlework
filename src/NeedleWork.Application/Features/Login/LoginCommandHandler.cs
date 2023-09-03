using MediatR;
using NeedleWork.Application.Abstractions;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Application.Features.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetByEmailAndPasswordAsync(request.Email, request.Password);

        if (user is null)
            throw new InvalidCredentialsException();
    
        string token = _jwtProvider.Generate(user);

        return token;
    }
}