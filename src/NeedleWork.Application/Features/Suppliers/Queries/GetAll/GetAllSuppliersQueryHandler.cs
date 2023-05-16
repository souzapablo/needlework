using MediatR;
using NeedleWork.Application.Models;
using NeedleWork.Application.Repositories;
using NeedleWork.Application.ViewModels.Suppliers;

namespace NeedleWork.Application.Features.Suppliers.Queries.GetAll;

public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, PaginationResult<SupplierViewModel>>
{
    private readonly ISupplierRepository _supplierRepository;

    public GetAllSuppliersQueryHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<PaginationResult<SupplierViewModel>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
    {
        var suppliers = await _supplierRepository.GetAllAsync(request.Name, request.Page, request.PageSize);

        var supplierViewModels = suppliers.Data.Select(supplier => new SupplierViewModel(
            supplier.Id,
            supplier.Name,
            supplier.Contact));

        return new PaginationResult<SupplierViewModel>
        {
            ItemsCount = suppliers.ItemsCount,
            Page = suppliers.Page,
            PageSize = suppliers.PageSize,
            TotalPages = suppliers.TotalPages,
            Data = supplierViewModels
        };
    }
}
