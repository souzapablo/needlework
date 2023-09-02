using NeedleWork.Application.Features.Users.Commands.Create;
using NeedleWork.Core.Exceptions;

namespace NeedleWork.UnitTests.Features.Commands.Users;

public class CreateUserCommandHandlerTests
{
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();

    [Fact]
    [DisplayName("Given a valid input should create product")]
    public async Task GivenAValidInputShouldCreateProduct()
    {
        // Given
        CreateUserCommand command = new("Teste", "Testy", "test@email.com", "test", DateOnly.MaxValue);
        CreateUserCommandHandler commandHandler = new(_userRepository);
        
        _userRepository.IsEmailRegistered(Arg.Any<string>())
            .Returns(false);

        // When
        long result = await commandHandler.Handle(command, new CancellationToken());

        // Then
        await _userRepository.Received(1)
            .IsEmailRegistered(Arg.Any<string>());
        await _userRepository.Received(1)
            .CreateAsync(Arg.Any<User>());
    }

    [Fact]
    [DisplayName("Given an already registered e-mail should throw exception")]
    public async Task GivenAnAlreadyRegisteredEmailShouldThrowException()
    {
        // Given
        CreateUserCommand command = new("Teste", "Testy", "test@email.com", "test", DateOnly.MaxValue);
        CreateUserCommandHandler commandHandler = new(_userRepository);

        _userRepository.IsEmailRegistered(Arg.Any<string>())
            .Returns(true);
        
        // When
        Func<Task> result = async ()
            => await commandHandler.Handle(command, new CancellationToken());

        // Then
        await result.Should()
            .ThrowAsync<EmailAlreadyRegisteredException>()
            .WithMessage("E-mail already registered");
        await _userRepository.Received(0)
            .CreateAsync(Arg.Any<User>());
    }
}