using NeedleWork.Application.Features.Purchases.Commands.Create;
using NeedleWork.Core.Exceptions;

namespace NeedleWork.UnitTests.Features.Commands.Purchases;

public class CreatePurchaseCommandHandlerTests
{
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly IProductRepository _productRepository = Substitute.For<IProductRepository>();
    private readonly IPurchaseRepository _purchaseRepository = Substitute.For<IPurchaseRepository>();

    [Fact]
    [DisplayName("Should create a new purchase when valid input")]
    public async Task ShouldCreateANewPurchaseWhenValidInput()
    {
        // Given
        Product product = ProductFaker.GenerateProduct;

        CreatePurchaseCommand command = new(1L, 2L, 3m, DateTime.Now);

        CreatePurchaseCommandHandler commandHandler = new(_purchaseRepository, _productRepository, _userRepository);

        _userRepository.VerifyIfExists(Arg.Any<long>())
            .Returns(true);

        _productRepository.GetByIdAsync(Arg.Any<long>())
            .Returns(product);

        // When
        await commandHandler.Handle(command, new CancellationToken());

        // Then
        await _productRepository.Received(1)
            .GetByIdAsync(Arg.Any<long>());

        await _userRepository.Received(1)
            .VerifyIfExists(Arg.Any<long>());

        await _purchaseRepository.Received(1)
            .CreateAsync(Arg.Any<Purchase>());
    }

    [Fact]
    [DisplayName("Should throw exception when user does not exist")]
    public async Task ShouldThrowExceptionWhenUserDoesNotExist()
    {
        // Given
        CreatePurchaseCommand command = new(1L, 2L, 3m, DateTime.Now);

        CreatePurchaseCommandHandler commandHandler = new(_purchaseRepository, _productRepository, _userRepository);

        _userRepository.VerifyIfExists(Arg.Any<long>())
            .Returns(false);

        // When
        Func<Task> sut = async () =>
            await commandHandler.Handle(command, new CancellationToken());

        // Then
        await sut.Should().ThrowAsync<NotFoundException>()
            .WithMessage("User with id 1 not found");
    }

    [Fact]
    [DisplayName("Should throw exception when product does not exist")]
    public async Task ShouldThrowExceptionWhenProductDoesNotExist()
    {
        // Given
        CreatePurchaseCommand command = new(1L, 2L, 3m, DateTime.Now);

        CreatePurchaseCommandHandler commandHandler = new(_purchaseRepository, _productRepository, _userRepository);

        _userRepository.VerifyIfExists(Arg.Any<long>())
            .Returns(true);

        // When
        Func<Task> sut = async () =>
            await commandHandler.Handle(command, new CancellationToken());

        // Then
        await sut.Should().ThrowAsync<NotFoundException>()
            .WithMessage("Product with id 2 not found");
    }
}