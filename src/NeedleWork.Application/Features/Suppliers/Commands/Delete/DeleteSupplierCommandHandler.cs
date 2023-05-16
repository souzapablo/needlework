using MediatR;
using NeedleWork.Application.Repositories;

namespace NeedleWork.Application.Features.Suppliers.Commands.Delete;

public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, Unit>
{
    private readonly ISupplierRepository _supplierRepository;

    public DeleteSupplierCommandHandler(ISupplierRepository suppliersRepository)
    {
        _supplierRepository = suppliersRepository;
    }

    public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
    {
        var supplier = await _supplierRepository.GetByIdAsync(request.Id);

        if (supplier is null)
            throw new Exception("Supplier not found");

        supplier.Delete();

        await _supplierRepository.UpdateAsync(supplier);

        return Unit.Value;
    }
}
