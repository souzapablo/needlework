using MediatR;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Repositories;
using NeedleWork.Core.Shared;

namespace NeedleWork.Application.Features.Purchases.Commands.AddItem;

public class AddPurchaseItemCommandHandler : IRequestHandler<AddPurchaseItemCommand, Unit>
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IProductRepository _productRepository;

    public AddPurchaseItemCommandHandler(IPurchaseRepository purchaseRepository, IProductRepository productRepository)
    {
        _purchaseRepository = purchaseRepository;
        _productRepository = productRepository;
    }


    public async Task<Unit> Handle(AddPurchaseItemCommand request, CancellationToken cancellationToken)
    {
        Purchase? purchase = await _purchaseRepository.GetByIdAsync(request.PurchaseId);

        if (purchase is null)
            throw new NotFoundException(Errors.PurchaseNotFound(request.PurchaseId));
        
        Product? product = await _productRepository.GetByIdAsync(request.ProductId);

        if (product is null)
            throw new NotFoundException(Errors.ProductNotFound(request.ProductId));

        PurchaseItem purchaseItem = new(product, request.Quantity);

        purchase.AddItem(purchaseItem);

        await _purchaseRepository.UpdateAsync(purchase);
        
        return Unit.Value;
    }

}