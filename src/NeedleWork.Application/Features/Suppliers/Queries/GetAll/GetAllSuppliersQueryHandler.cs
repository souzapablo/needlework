using MediatR;
using NeedleWork.Application.ViewModels.Suppliers;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Application.Features.Suppliers.Queries.GetAll;

public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, List<SupplierViewModel>>
{
    private readonly ISupplierRepository _supplierRepository;

    public GetAllSuppliersQueryHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<List<SupplierViewModel>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
    {
        List<Supplier> suppliers = await _supplierRepository.GetAllAsync();

        return suppliers.Select(x => new SupplierViewModel(
            x.Id,
            x.Name
        )).ToList();
    }
}