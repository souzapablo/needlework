namespace NeedleWork.UnitTests.Fakers;

public static class SupplierFaker
{
    public static Supplier GenerateSupplier =>
        new Faker<Supplier>("pt_BR")
            .RuleFor(x => x.Id, f => f.IndexFaker)
            .RuleFor(x => x.Name, f => f.Name.FullName())
            .RuleFor(x => x.Contact, f => f.Internet.Email())
            .Generate();
}