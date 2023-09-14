using MediatR;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Repositories;
using NeedleWork.Core.Shared;

namespace NeedleWork.Application.Features.Purchases.Commands.Delete;

public record DeletePurchaseCommandHandler : IRequestHandler<DeletePurchaseCommand, Unit>
{
    private readonly IPurchaseRepository _purchaseRepository;

    public DeletePurchaseCommandHandler(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public async Task<Unit> Handle(DeletePurchaseCommand request, CancellationToken cancellationToken)
    {
        Purchase? purchase = await _purchaseRepository.GetByIdAsync(request.Id);

        if (purchase is null)
            throw new NotFoundException(Errors.PurchaseNotFound(request.Id));

        purchase.Delete();

        await _purchaseRepository.UpdateAsync(purchase);
        
        return Unit.Value;
    }

}