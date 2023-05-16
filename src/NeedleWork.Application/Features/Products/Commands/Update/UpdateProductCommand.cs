using MediatR;

namespace NeedleWork.Application.Features.Products.Commands.Update;

public record UpdateProductCommand(
    long Id,
    string Description,
    decimal Price) : IRequest<Unit>;
