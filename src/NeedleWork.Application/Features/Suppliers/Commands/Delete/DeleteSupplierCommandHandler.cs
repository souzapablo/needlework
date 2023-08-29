using MediatR;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Repositories;
using NeedleWork.Core.Shared;

namespace NeedleWork.Application.Features.Suppliers.Commands.Delete;

public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, Unit>
{
    private readonly ISupplierRepository _supplierRepository;

    public DeleteSupplierCommandHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
    {
        Supplier? supplier = await _supplierRepository.GetByIdAsync(request.Id);

        if (supplier is null)
            throw new NotFoundException(Errors.SupplierNotFound(request.Id));

        supplier.Delete();

        await _supplierRepository.UpdateAsync(supplier);

        return Unit.Value;
    }
}