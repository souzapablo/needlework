using MediatR;
using NeedleWork.Application.ViewModels.Suppliers;
using NeedleWork.Infrastructure.Shared;

namespace NeedleWork.Application.Features.Suppliers.Queries.Get;

public record GetSuppliersQuery(
    string? SearchTerm,
    string? SortColumn,
    string? SortOrder,
    int Page,
    int PageSize) : IRequest<PagedList<SupplierViewModel>>;