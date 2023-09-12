namespace NeedleWork.UnitTests.Entities;
public class PurchaseTests
{
    [Fact]
    [DisplayName("Given a new item in purchase total should be recalculated")]
    public void GivenANewItemInPurchaseTotalShouldBeRecalculated()
    {
        // Given
        Purchase purchase = PurchaseFaker.GeneratePurchase;
        PurchaseItem purchaseItem = PurchaseFaker.GeneratePurchaseItem;
        decimal total = purchaseItem.Product.Price * purchaseItem.Quantity;

        // When
        purchase.AddItem(purchaseItem);

        // Then
        purchase.Total.Should().Be(total);
        purchase.Items.Should().HaveCount(1);
        purchase.Items.Should().Contain(purchaseItem);
    }
}
