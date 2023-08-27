using MediatR;
using NeedleWork.Application.ViewModels.Products;
using NeedleWork.Application.ViewModels.Suppliers;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Application.Features.Suppliers.Queries.GetById;

public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, SupplierDetailsViewModel>
{
    private readonly ISupplierRepository _supplierRepository;

    public GetSupplierByIdQueryHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<SupplierDetailsViewModel> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
    {
        Supplier? supplier = await _supplierRepository.GetByIdAsync(request.Id);

        if (supplier is null)
            throw new Exception("Supplier not found");

        return new SupplierDetailsViewModel(
            supplier.Id,
            supplier.Name,
            supplier.Contact,
            supplier.Products.Select(p => new ProductViewModel(p.Id, p.Description)).ToList()
        );
    }
}