using MediatR;
using NeedleWork.Application.ViewModels.Products;
using NeedleWork.Application.ViewModels.Suppliers;
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
        var supplier = await _supplierRepository.GetByIdAsync(request.Id, supplier => supplier.Products);

        return supplier is null
            ? throw new Exception("Supplier not found")
            : new SupplierDetailsViewModel(
            supplier.Id,
            supplier.Name,
            supplier.Contact,
            supplier.Products.Select(product =>
                new SupplierProductViewModel(product.Id, product.Description, product.Price)));
        ;
    }
}
