using MediatR;
using NeedleWork.Application.ViewModels.Suppliers;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Application.Features.Suppliers.Queries.Get;

public class GetSuppliersQueryHandler : IRequestHandler<GetSuppliersQuery, List<SupplierViewModel>>
{
    private readonly ISupplierRepository _supplierRepository;

    public GetSuppliersQueryHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<List<SupplierViewModel>> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
    {
        List<Supplier> suppliers = await _supplierRepository.GetAllAsync(
            request.SearchTerm,
            request.SortColumn,
            request.SortOrder);

        return suppliers.Select(x => new SupplierViewModel(
            x.Id,
            x.Name
        )).ToList();
    }
}