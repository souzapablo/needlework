using MediatR;
using NeedleWork.Application.ViewModels.Purchases;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;
using NeedleWork.Infrastructure.Shared;

namespace NeedleWork.Application.Features.Purchases.Queries.Get;

public class GetPurchasesQueryHandler : IRequestHandler<GetPurchasesQuery, PagedList<PurchaseViewModel>>
{
    private readonly IPurchaseRepository _purchaseRepository;

    public GetPurchasesQueryHandler(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public async Task<PagedList<PurchaseViewModel>> Handle(GetPurchasesQuery request, CancellationToken cancellationToken)
    {
        List<Purchase> purchases = await _purchaseRepository.GetAsync(request.UserId, request.SortColumn, request.SortOrder, request.Page, request.PageSize);

        List<PurchaseViewModel> purchasesViewModels = purchases.Select(x => 
            new PurchaseViewModel(
                x.Id, 
                x.Total, 
                x.PurchaseDate))
            .ToList();
        
        return PagedList<PurchaseViewModel>.Create(purchasesViewModels, request.Page, request.PageSize);
    }

}