using MediatR;

namespace NeedleWork.Application.Features.Suppliers.Commands.Create;

public record CreateSupplierCommand(
    string Name,
    string Contact) : IRequest<long>;