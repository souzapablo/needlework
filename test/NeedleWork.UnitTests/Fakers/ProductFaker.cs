namespace NeedleWork.UnitTests.Fakers;

public static class ProductFaker
{
    public static Product GenerateProduct =>
        new Faker<Product>("pt_BR")
            .RuleFor(x => x.Id, f => f.IndexFaker)
            .RuleFor(x => x.Description, f => f.Commerce.Product())
            .RuleFor(x => x.Price, f => f.Random.Decimal(1.5M, 15M))
            .RuleFor(x => x.UnitOfMeasurement, f => f.PickRandom<UnitOfMeasurement>())
            .RuleFor(x => x.Supplier, f => SupplierFaker.GenerateSupplier)
            .Generate();
}