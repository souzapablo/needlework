using MediatR;

namespace NeedleWork.Application.Features.Purchases.Commands.Delete;

public record DeletePurchaseCommand(
    long Id
) : IRequest<Unit>;