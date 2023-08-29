using MediatR;

namespace NeedleWork.Application.Features.Suppliers.Commands.Delete;

public record DeleteSupplierCommand(long Id) : IRequest<Unit>;