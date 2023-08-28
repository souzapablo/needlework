namespace NeedleWork.UnitTests.Entities;

public class SupplierTests
{
    [Fact]
    [DisplayName("Given a valid input supplier should update contact")]
    public void GivenAValidInputSupplierShouldUpdateContact()
    {
        // Given
        Supplier supplier = new("Test", "Test");

        // When
        supplier.UpdateContact("New contact");

        // Then
        supplier.Contact.Should().Be("New contact");
    }
}