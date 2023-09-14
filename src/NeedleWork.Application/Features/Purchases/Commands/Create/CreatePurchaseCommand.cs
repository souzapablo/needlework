using MediatR;

namespace NeedleWork.Application.Features.Purchases.Commands.Create;
public record CreatePurchaseCommand(
    long UserId,
    long ProductId,
    decimal Quantity,
    DateTime PurchaseDate) : IRequest<long>;