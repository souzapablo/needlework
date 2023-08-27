using System.ComponentModel;
using NeedleWork.Application.Features.Suppliers.Queries.GetById;
using NeedleWork.Application.ViewModels.Suppliers;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace NeedleWork.UnitTests.Features.Suppliers.Queries;

public class GetSupplierByIdQueryHandlerTests
{
    private readonly ISupplierRepository _supplierRepository = Substitute.For<ISupplierRepository>();

    [Fact]
    [DisplayName("Given a valid id should return a detailed supplier view model")]
    public async Task GivenAValidIdShouldReturnASupplier()
    {
        // Arrange
        GetSupplierByIdQuery query = new(1);
        GetSupplierByIdQueryHandler queryHandler = new(_supplierRepository);

        _supplierRepository.GetByIdAsync(1)
            .Returns(new Supplier("Teste", "Teste"));

        // Act
        SupplierDetailsViewModel result = await queryHandler.Handle(query, new CancellationToken());

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<SupplierDetailsViewModel>();
        await _supplierRepository.Received(1).GetByIdAsync(1);
    }   

    [Fact]
    [DisplayName("Given an invalid id should throw exception")]
    public async Task GivenAnInvalidIdShouldThrowException()
    {
        // Arrange
        GetSupplierByIdQuery query = new(1);
        GetSupplierByIdQueryHandler queryHandler = new(_supplierRepository);

        _supplierRepository.GetByIdAsync(1)
            .ReturnsNull();

        // Act
        Func<Task> result = async () =>
            await queryHandler.Handle(query, new CancellationToken());

        // Assert
        await result.Should().ThrowAsync<Exception>()
            .WithMessage("Supplier not found");
    } 
}