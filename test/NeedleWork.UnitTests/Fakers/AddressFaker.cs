namespace NeedleWork.UnitTests.Fakers;

public static class AddressFaker
{
    public static Address GenerateAddress => 
        new Faker<Address>("pt_BR")
            .RuleFor(x => x.Id, f => f.IndexFaker)
            .RuleFor(x => x.Cep, f => f.Address.ZipCode())
            .RuleFor(x => x.City, f => f.Address.City())
            .RuleFor(x => x.Neighborhood, f => f.Address.CityPrefix())
            .RuleFor(x => x.Number, f => f.Random.Int(1, 100))
            .RuleFor(x => x.State, f => f.Address.StateAbbr())
            .RuleFor(x => x.Street, f => f.Address.StreetName());
}