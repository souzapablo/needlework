using NeedleWork.Application.Features.Addresses;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Services;
using NeedleWork.Infrastructure.Models;

namespace NeedleWork.UnitTests.Features.Commands.Addresses;

public class CreateAddressCommandHandlerTests
{
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly IViaCepService _viaCepService = Substitute.For<IViaCepService>();

    [Fact(DisplayName = "Given a valid input should add address to user")]
    public async Task GivenAValidInputShouldAddAddressToUser()
    {
        // Given
        CreateAddressCommand command = new(1, "123", 123, null);
        CreateAddressCommandHandler commandHandler = new(_userRepository, _viaCepService);

        Address address = AddressFaker.GenerateAddress;
        var viaCepAddress = new ViaCepAddress
        {
            Cep = address.Cep,
            Street = address.Street,
            State = address.State,
            Neighborhood = address.Neighborhood,
            City = address.City        
        };
        User user = UserFaker.GenerateUser;

        _userRepository.GetByIdAsync(Arg.Any<long>())
            .Returns(user);

        _viaCepService.GetAddressAsync(Arg.Any<string>())
            .Returns(viaCepAddress);

        // When
        await commandHandler.Handle(command, new CancellationToken());   

        // Assert
        user.Addresses.Count().Should().Be(1);
        await _userRepository.Received(1)
            .UpdateAsync(Arg.Any<User>());          
    }

    [Fact(DisplayName = "Given an invalid user id should throw exception")]
    public async Task GivenAnInvalidUserIdShouldThrowException()
    {
        // Given
        CreateAddressCommand command = new(1, "123", 123, null);
        CreateAddressCommandHandler commandHandler = new(_userRepository, _viaCepService);

        User user = UserFaker.GenerateUser;

        _userRepository.GetByIdAsync(Arg.Any<long>())
            .ReturnsNull();

        // When
        Func<Task> func = async () => 
            await commandHandler.Handle(command, new CancellationToken());   

        // Then
        await func.Should().ThrowAsync<NotFoundException>()
            .WithMessage("User with id 1 not found");     
    }

    [Fact(DisplayName = "Given an  invalid address should throw exception")]
    public async Task GivenAnInvalidAddressShouldThrowException()
    {
        // Given
        CreateAddressCommand command = new(1, "123", 123, null);
        CreateAddressCommandHandler commandHandler = new(_userRepository, _viaCepService);

        User user = UserFaker.GenerateUser;

        _userRepository.GetByIdAsync(Arg.Any<long>())
            .Returns(user);

        _viaCepService.GetAddressAsync(Arg.Any<string>())
            .ReturnsNull();

        // When
        Func<Task> func = async () => 
            await commandHandler.Handle(command, new CancellationToken());   

        // Then
        await func.Should().ThrowAsync<NotFoundException>()
            .WithMessage("Address with CEP 123 not found");
    }
}