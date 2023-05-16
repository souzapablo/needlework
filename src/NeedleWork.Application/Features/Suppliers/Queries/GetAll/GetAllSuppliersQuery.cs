using MediatR;
using NeedleWork.Application.Models;
using NeedleWork.Application.ViewModels.Suppliers;

namespace NeedleWork.Application.Features.Suppliers.Queries.GetAll;

public record GetAllSuppliersQuery(
    string? Name,
    int Page,
    int PageSize) : IRequest<PaginationResult<SupplierViewModel>>;