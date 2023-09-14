using MediatR;
using NeedleWork.Application.ViewModels.Purchases;
using NeedleWork.Infrastructure.Shared;

namespace NeedleWork.Application.Features.Purchases.Queries.Get;

public record GetPurchasesQuery(
    string? UserId,
    string? SortColumn,
    string? SortOrder,
    int Page,
    int PageSize
) : IRequest<PagedList<PurchaseViewModel>>;