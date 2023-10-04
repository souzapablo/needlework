using NeedleWork.Core.Entities;

namespace NeedleWork.Core.Extensions;

public class AddressBuilder
{
    private readonly Address _address;

    public AddressBuilder(string cep)
    {
        _address = new(cep);
    }

    public AddressBuilder WithCity(string city, string state)
    {
        _address.City = city;
        _address.State = state;

        return this;
    }

    public AddressBuilder WithNeiborhood(string neighborhood)
    {
        _address.Neighborhood = neighborhood;

        return this;
    }

    public AddressBuilder WithStreetAndNumber(string street, int number)
    {
        _address.Street = street;
        _address.Number = number;

        return this;
    }

    public Address Build()
    {
        return _address;
    }
}