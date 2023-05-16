using MediatR;
using NeedleWork.Application.Repositories;

namespace NeedleWork.Application.Features.Suppliers.Commands.Update;

public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Unit>
{
    private readonly ISupplierRepository _supplierRepository;

    public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
    {
        var supplier = await _supplierRepository.GetByIdAsync(request.Id);

        if (supplier is null)
            throw new Exception("Supplier not found");

        supplier.UpdateName(request.Name);
        supplier.UpdateContact(request.Contact);

        await _supplierRepository.UpdateAsync(supplier);

        return Unit.Value;
    }
}
