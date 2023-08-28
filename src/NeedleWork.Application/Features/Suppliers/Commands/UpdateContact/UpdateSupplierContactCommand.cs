using MediatR;

namespace NeedleWork.Application.Features.Suppliers.Commands.UpdateName;

public record UpdateSupplierContactCommand(
    long Id,
    string NewContact) : IRequest<Unit>;