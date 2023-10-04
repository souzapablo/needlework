namespace NeedleWork.Application.InputModels.Addresses;

public record CreateAddressInputModel(
    string Cep,
    int Number,
    string? Complement
);