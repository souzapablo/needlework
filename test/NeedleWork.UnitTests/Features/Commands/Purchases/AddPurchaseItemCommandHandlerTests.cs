using NeedleWork.Application.Features.Purchases.Commands.AddItem;
using NeedleWork.Core.Exceptions;

namespace NeedleWork.UnitTests.Features.Commands.Purchases;

public class AddPurchaseItemCommandHandlerTests
{
    private readonly IPurchaseRepository _purchaseRepository = Substitute.For<IPurchaseRepository>();
    private readonly IProductRepository _productRepository = Substitute.For<IProductRepository>();

    [Fact]
    [DisplayName("Should add a new item to purcahse list")]
    public async Task ShouldAddANewIemToPurchaseList()
    {
        // Given
        Purchase purchase = PurchaseFaker.GeneratePurchase;
        purchase.AddItem(PurchaseFaker.GeneratePurchaseItem);

        Product product = ProductFaker.GenerateProduct;

        AddPurchaseItemCommand command = new(1L, 2L, 3.0m);

        AddPurchaseItemCommandHandler commandHandler = new(_purchaseRepository, _productRepository);

        _purchaseRepository.GetByIdAsync(Arg.Any<long>())
            .Returns(purchase);

        _productRepository.GetByIdAsync(Arg.Any<long>())
            .Returns(product);

        // When
        await commandHandler.Handle(command, new CancellationToken());

        // Then
        purchase.Items.Should().HaveCount(2);
        await _purchaseRepository.Received(1)
            .UpdateAsync(purchase);    
    }

    [Fact]
    [DisplayName("Should throw exception when invalid product")]
    public async Task ShouldThrowExceptionWhenInvalidProduct()
    {
        // Given
        Purchase purchase = PurchaseFaker.GeneratePurchase;
        purchase.AddItem(PurchaseFaker.GeneratePurchaseItem);

        AddPurchaseItemCommand command = new(1L, 2L, 3.0m);

        AddPurchaseItemCommandHandler commandHandler = new(_purchaseRepository, _productRepository);

        _purchaseRepository.GetByIdAsync(Arg.Any<long>())
            .Returns(purchase);

        _productRepository.GetByIdAsync(Arg.Any<long>())
            .ReturnsNull();

        // When
        Func<Task> sut = async () => 
            await commandHandler.Handle(command, new CancellationToken());

        // Then
        await sut.Should().ThrowAsync<NotFoundException>()
            .WithMessage("Product with id 2 not found");
    }

    [Fact]
    [DisplayName("Should throw exception when invalid purchase")]
    public async Task ShouldThrowExceptionWhenInvalidPurchase()
    {
        // Given
        AddPurchaseItemCommand command = new(1L, 2L, 3.0m);

        AddPurchaseItemCommandHandler commandHandler = new(_purchaseRepository, _productRepository);

        _purchaseRepository.GetByIdAsync(Arg.Any<long>())
            .ReturnsNull();

        // When
        Func<Task> sut = async () => 
            await commandHandler.Handle(command, new CancellationToken());

        // Then
        await sut.Should().ThrowAsync<NotFoundException>()
            .WithMessage("Purchase with id 1 not found");
    }
}