using MediatR;

namespace NeedleWork.Application.Features.Products.Commands.Create;

public record CreateProductCommand(
    long SupplierId,
    string Description,
    decimal Price) : IRequest<long>;