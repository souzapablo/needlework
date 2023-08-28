using MediatR;
using NeedleWork.Application.ViewModels.Suppliers;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;
using NeedleWork.Infrastructure.Shared;

namespace NeedleWork.Application.Features.Suppliers.Queries.Get;

public class GetSuppliersQueryHandler : IRequestHandler<GetSuppliersQuery, PagedList<SupplierViewModel>>
{
    private readonly ISupplierRepository _supplierRepository;

    public GetSuppliersQueryHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<PagedList<SupplierViewModel>> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
    {
        List<Supplier> suppliers = await _supplierRepository.GetAsync(
            request.SearchTerm,
            request.SortColumn,
            request.SortOrder,
            request.Page,
            request.PageSize);
        
        List<SupplierViewModel> supplierViewModels = suppliers.Select(x => new SupplierViewModel(
            x.Id,
            x.Name
        )).ToList();

        return PagedList<SupplierViewModel>.Create(supplierViewModels, request.Page, request.PageSize);
    }
}