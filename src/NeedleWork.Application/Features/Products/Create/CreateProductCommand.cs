using MediatR;
using NeedleWork.Core.Enums;

namespace NeedleWork.Application.Features.Products.Create;

public record CreateProductCommand(
    long SupplierId,
    string Description,
    decimal Price,
    UnitOfMeasurement UnitOfMeasurement) : IRequest<long>;