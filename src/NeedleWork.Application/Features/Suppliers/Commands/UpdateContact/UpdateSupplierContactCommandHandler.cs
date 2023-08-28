using MediatR;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Repositories;
using NeedleWork.Core.Shared;

namespace NeedleWork.Application.Features.Suppliers.Commands.UpdateName;

public class UpdateSupplierContactCommandHandler : IRequestHandler<UpdateSupplierContactCommand, Unit>
{
    private readonly ISupplierRepository _supplierRepository;

    public UpdateSupplierContactCommandHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<Unit> Handle(UpdateSupplierContactCommand request, CancellationToken cancellationToken)
    {
        Supplier? supplier = await _supplierRepository.GetByIdAsync(request.Id); 

        if (supplier is null)
            throw new NotFoundException(Errors.SupplierNotFound(request.Id));
        
        supplier.UpdateContact(request.NewContact);

        await _supplierRepository.UpdateAsync(supplier);

        return Unit.Value;
    }
}