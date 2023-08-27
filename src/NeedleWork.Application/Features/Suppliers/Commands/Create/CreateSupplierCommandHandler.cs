using MediatR;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Application.Features.Suppliers.Commands.Create;

public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, long>
{
    private readonly ISupplierRepository _supplierRepository;

    public CreateSupplierCommandHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<long> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
    {
        Supplier supplier = new(request.Name, request.Contact);

        await _supplierRepository.CreateAsync(supplier);

        return supplier.Id;
    }
}