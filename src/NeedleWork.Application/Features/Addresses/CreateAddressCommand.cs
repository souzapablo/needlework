using MediatR;

namespace NeedleWork.Application.Features.Addresses;

public record CreateAddressCommand(
    long UserId,
    string Cep,
    int Number,
    string? Complement
) : IRequest<long>;