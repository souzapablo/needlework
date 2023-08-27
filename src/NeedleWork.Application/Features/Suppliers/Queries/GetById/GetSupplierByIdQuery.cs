using MediatR;
using NeedleWork.Application.ViewModels.Suppliers;

namespace NeedleWork.Application.Features.Suppliers.Queries.GetById;

public record GetSupplierByIdQuery(
    long Id) : IRequest<SupplierDetailsViewModel>;