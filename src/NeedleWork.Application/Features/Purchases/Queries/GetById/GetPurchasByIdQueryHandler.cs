using MediatR;
using NeedleWork.Application.ViewModels.Purchases;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Repositories;
using NeedleWork.Core.Shared;

namespace NeedleWork.Application.Features.Purchases.Queries.GetById;
public class GetPurchasByIdQueryHandler : IRequestHandler<GetPurchaseByIdQuery, PurchaseDetailsViewModel>
{
    private readonly IPurchaseRepository _purchaseRepository;

    public GetPurchasByIdQueryHandler(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public async Task<PurchaseDetailsViewModel> Handle(GetPurchaseByIdQuery request, CancellationToken cancellationToken)
    {
        Purchase? purchase = await _purchaseRepository.GetByIdAsync(request.Id);

        if (purchase is null)
            throw new NotFoundException(Errors.PurchaseNotFound(request.Id));

        List<PurchaseItemViewModel> items = purchase.Items.Select(x =>
            new PurchaseItemViewModel(
                x.Product.Description, 
                x.Quantity, 
                x.Product.Price))
            .ToList();

        return new PurchaseDetailsViewModel(
            purchase.Id,
            items,
            purchase.Total,
            purchase.PurchaseDate);
    }
}
