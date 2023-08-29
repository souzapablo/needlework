using MediatR;
using NeedleWork.Application.ViewModels.Products;

namespace NeedleWork.Application.Features.Products.Queries.GetById;

public record GetProductByIdQuery(
    long Id) : IRequest<ProductDetailsViewModel>;
