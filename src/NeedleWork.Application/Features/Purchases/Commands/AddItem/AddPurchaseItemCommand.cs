using MediatR;

namespace NeedleWork.Application.Features.Purchases.Commands.AddItem;

public record AddPurchaseItemCommand(
    long PurchaseId,
    long ProductId,
    decimal Quantity
) : IRequest<Unit>;