using NeedleWork.Application.Features.Suppliers.Commands.Create;

namespace NeedleWork.UnitTests.Features.Suppliers;

public class CreateSupplierCommandHandlerTests
{
    private readonly ISupplierRepository _supplierRepository = Substitute.For<ISupplierRepository>();

    [Fact]
    public async Task GivenAValidInputShouldCreateNewSupplier()
    {
        // Arrange
        CreateSupplierCommand command = new(
            "Test",
            "Test"
        );
        CreateSupplierCommandHandler commandHandler = new(_supplierRepository);
        await _supplierRepository.CreateAsync(Arg.Any<Supplier>());

        // Act
        await commandHandler.Handle(command, new CancellationToken());

        // Assert
        await _supplierRepository.Received(1).CreateAsync(Arg.Any<Supplier>());            
    }
}