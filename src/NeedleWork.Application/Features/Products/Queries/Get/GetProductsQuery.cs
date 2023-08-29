using MediatR;
using NeedleWork.Application.ViewModels.Products;
using NeedleWork.Infrastructure.Shared;

namespace NeedleWork.Application.Features.Products.Queries.Get;

public record GetProductsQuery(
    string? SearchTerm,
    string? SortColumn,
    string? SortOrder,
    int Page,
    int PageSize
) : IRequest<PagedList<ProductViewModel>>;