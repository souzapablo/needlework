using NeedleWork.Application.Features.Products.Commands.Create;
using NeedleWork.Core.Exceptions;

namespace NeedleWork.UnitTests.Features.Commands.Products;

public class CreateProductCommandHandlerTests
{
    private readonly IProductRepository _productRepository = Substitute.For<IProductRepository>();
    private readonly ISupplierRepository _supplierRepository = Substitute.For<ISupplierRepository>();

    [Fact]
    [DisplayName("Given a valid input should create product")]
    public async Task GivenAValidInputShouldCreateProduct()
    {
        // Given
        CreateProductCommand command = new(1, "Test description", 20M, UnitOfMeasurement.Meter);
        CreateProductCommandHander commandHandler = new(_productRepository, _supplierRepository);

        _supplierRepository.VerifyIfExists(Arg.Any<long>())
            .Returns(true);

        // When
        await commandHandler.Handle(command, new CancellationToken());

        // Then
        await _supplierRepository.Received(1)
            .VerifyIfExists(Arg.Any<long>());
        await _productRepository.Received(1)
            .CreateAsync(Arg.Any<Product>());
    }

    [Fact]
    [DisplayName("Given an invalid supplier id should throw exception")]
    public async Task GivenAnInvalidSupplierIdShouldThrowException()
    {
        // Given
        CreateProductCommand command = new(1, "Test description", 20M, UnitOfMeasurement.Meter);
        CreateProductCommandHander commandHandler = new(_productRepository, _supplierRepository);

        _supplierRepository.VerifyIfExists(Arg.Any<long>())
            .Returns(false);

        // When
        Func<Task> result = async () =>
            await commandHandler.Handle(command, new CancellationToken());

        // Then
        await result.Should().ThrowAsync<NotFoundException>()
            .WithMessage("Supplier with id 1 not found");
    }
}