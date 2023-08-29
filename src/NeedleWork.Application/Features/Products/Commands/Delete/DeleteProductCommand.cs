using MediatR;

namespace NeedleWork.Application.Features.Products.Commands.Delete;

public record DeleteProductCommand(
    long Id) : IRequest<Unit>;