using MediatR;
using NeedleWork.Application.ViewModels.Suppliers;
using NeedleWork.Core.Models;

namespace NeedleWork.Application.Features.Suppliers.Queries.GetAll;

public record GetAllSuppliersQuery(
    string? Name,
    int Page,
    int PageSize) : IRequest<PaginationResult<SupplierViewModel>>;