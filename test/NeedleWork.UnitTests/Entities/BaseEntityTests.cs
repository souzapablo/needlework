namespace NeedleWork.UnitTests.Entities;

public class BaseEntityTests
{
    [Fact]
    [DisplayName("Given a deletion entities should change IsActive status to false")]
    public void GivenDeleteRequestBaseEntityShouldChangeIsActiveStatus() 
    {
        // Given
        Product product = new(1, "Test product", 2M, UnitOfMeasurement.Meter);

        // When
        product.Delete();

        // Then
        product.IsActive.Should().BeFalse();
    }   
}