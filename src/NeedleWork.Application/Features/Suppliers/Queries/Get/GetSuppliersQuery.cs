using MediatR;
using NeedleWork.Application.ViewModels.Suppliers;

namespace NeedleWork.Application.Features.Suppliers.Queries.Get;

public record GetSuppliersQuery(
    string? SearchTerm,
    string? SortColumn,
    string? SortOrder) : IRequest<List<SupplierViewModel>>;