using MediatR;
using NeedleWork.Application.ViewModels.Purchases;

namespace NeedleWork.Application.Features.Purchases.Queries.GetById;
public record GetPurchaseByIdQuery(long Id) : IRequest<PurchaseDetailsViewModel>;
