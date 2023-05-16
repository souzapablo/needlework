using MediatR;
using NeedleWork.Application.ViewModels.Products;
using NeedleWork.Core.Models;

namespace NeedleWork.Application.Features.Products.Queries.GetAll;

public record GetAllProductsQuery(
    string? Description,
    int Page,
    int PageSize) : IRequest<PaginationResult<ProductViewModel>>;