using MediatR;
using NeedleWork.Application.Repositories;
using NeedleWork.Core.Entities;

namespace NeedleWork.Application.Features.Suppliers.Commands.Create;

public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, long>
{
    private readonly ISupplierRepository _supplierRepoistory;

    public CreateSupplierCommandHandler(ISupplierRepository supplierRepoistory)
    {
        _supplierRepoistory = supplierRepoistory;
    }

    public async Task<long> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
    {
        var supplier = new Supplier(request.Name, request.Contact);

        await _supplierRepoistory.CreateAsync(supplier);

        return supplier.Id;
    }
}
