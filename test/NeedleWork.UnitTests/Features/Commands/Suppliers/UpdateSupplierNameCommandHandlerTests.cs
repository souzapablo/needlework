using NeedleWork.Application.Features.Suppliers.Commands.UpdateName;
using NeedleWork.Core.Exceptions;

namespace NeedleWork.UnitTests.Features.Commands.Suppliers;

public class UpdateSupplierNameCommandHandlerTests
{
    private readonly ISupplierRepository _supplierRepository = Substitute.For<ISupplierRepository>();

    [Fact]
    [DisplayName("Given a valid input supplier name should update")]
    public async Task GivenAValidInputSupplierNameShouldUpdate()
    {
        // Given
        Supplier supplier = new("Test", "Test");
        UpdateSupplierContactCommand command = new(1, "Valid new contact");
        UpdateSupplierContactCommandHandler commandHandler = new(_supplierRepository);
        _supplierRepository.GetByIdAsync(Arg.Any<long>())
            .Returns(supplier);

        // When
        await commandHandler.Handle(command, new CancellationToken());

        // Then
        supplier.Contact.Should().Be("Valid new contact");
        await _supplierRepository.Received(1).UpdateAsync(supplier);
    }

    [Fact]
    [DisplayName("Given an invalid id should throw exception")]
    public async Task GivenAnInvalidIdShouldThrowException()
    {
        // Arrange
        UpdateSupplierContactCommand command = new(1, "Valid new contact");
        UpdateSupplierContactCommandHandler commandHandler = new(_supplierRepository);

        _supplierRepository.GetByIdAsync(1)
            .ReturnsNull();

        // Act
        Func<Task> result = async () =>
            await commandHandler.Handle(command, new CancellationToken());

        // Assert
        await result.Should().ThrowAsync<NotFoundException>()
            .WithMessage("Supplier with id 1 not found");
    }
}