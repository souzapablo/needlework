using NeedleWork.Application.Features.Products.Queries.GetById;
using NeedleWork.Application.ViewModels.Products;
using NeedleWork.Core.Exceptions;

namespace NeedleWork.UnitTests.Features.Queries.Products;

public class GetProductByIdQueryHandlerTests
{
    private readonly IProductRepository _productRepository = Substitute.For<IProductRepository>();

    [Fact]
    [DisplayName("Given a valid id should return product details")]
    public async Task GivenAValidIdShouldReturnProductDetails()
    {
        // Given
        GetProductByIdQuery query = new(1);
        GetProductByIdQueryHandler queryHandler = new(_productRepository);

        _productRepository.GetByIdAsync(Arg.Any<long>())
            .Returns(ProductFaker.GenerateProduct);

        // When
        ProductDetailsViewModel result = await queryHandler.Handle(query, new CancellationToken());

        // Then
        result.Should().NotBeNull();
        result.Should().BeOfType<ProductDetailsViewModel>();
    }

    [Fact]
    [DisplayName("Given an invalid id should trhow exception")]
    public async Task GivenAnInvalidIdShouldThrowException()
    {
        // Given
        GetProductByIdQuery query = new(1);
        GetProductByIdQueryHandler queryHandler = new(_productRepository);

        _productRepository.GetByIdAsync(Arg.Any<long>())
            .ReturnsNull();

        // When
        Func<Task> result = async () =>
            await queryHandler.Handle(query, new CancellationToken());

        // Then
        await result.Should().ThrowAsync<NotFoundException>()
            .WithMessage("Product with id 1 not found");
    }
}