using MediatR;

namespace NeedleWork.Application.Features.Suppliers.Commands.Update;

public record UpdateSupplierCommand(
    long Id,
    string Name,
    string Contact) : IRequest<Unit>;
