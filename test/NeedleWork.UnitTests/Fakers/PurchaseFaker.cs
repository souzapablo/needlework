namespace NeedleWork.UnitTests.Fakers;
public static class PurchaseFaker
{
    public static Purchase GeneratePurchase =>
        new Faker<Purchase>("pt_BR")
            .RuleFor(x => x.Id, f => f.IndexFaker)
            .RuleFor(x => x.UserId, f => f.IndexFaker)
            .RuleFor(x => x.PurchaseDate, f => f.Date.Recent())
            .Generate();

    public static PurchaseItem GeneratePurchaseItem =>
        new Faker<PurchaseItem>("pt_BR")
            .RuleFor(x => x.Id, f => f.IndexFaker)
            .RuleFor(x => x.Product, ProductFaker.GenerateProduct)
            .RuleFor(x => x.Quantity, f => f.Random.Decimal(0m, 3m))
            .Generate();
}
