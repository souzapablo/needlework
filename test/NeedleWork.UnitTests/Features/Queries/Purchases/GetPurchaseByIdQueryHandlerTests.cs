using NeedleWork.Application.Features.Purchases.Queries.GetById;
using NeedleWork.Application.ViewModels.Purchases;
using NeedleWork.Core.Exceptions;

namespace NeedleWork.UnitTests.Features.Queries.Purchases;
public class GetPurchaseByIdQueryHandlerTests
{
    private readonly IPurchaseRepository _purchaseRepository = Substitute.For<IPurchaseRepository>();

    [Fact]
    [DisplayName("Given a valid id should return purchase details")]
    public async Task GivenAValidIdShouldReturnPurchaseDetails()
    {
        // Given
        Purchase purchase = PurchaseFaker.GeneratePurchase;
        GetPurchaseByIdQuery query = new(1L);
        GetPurchasByIdQueryHandler queryHandler = new(_purchaseRepository);

        _purchaseRepository.GetByIdAsync(Arg.Any<long>())
            .Returns(purchase);

        // When
        PurchaseDetailsViewModel sut = await queryHandler.Handle(query, new CancellationToken());

        // Then
        sut.Should().NotBeNull();
        sut.Should().BeOfType<PurchaseDetailsViewModel>();
    }

    [Fact]
    [DisplayName("Given an invalid id should throw exception")]
    public async Task GivenAnInvalidIdShouldThrowException()
    {
        // Given
        GetPurchaseByIdQuery query = new(1L);
        GetPurchasByIdQueryHandler queryHandler = new(_purchaseRepository);

        // When
        Func<Task> sut = async () => 
            await queryHandler.Handle(query, new CancellationToken());

        // Then
        await sut.Should().ThrowAsync<NotFoundException>()
            .WithMessage("Purchase with id 1 not found");
    }
}
