using MediatR;
using NeedleWork.Application.ViewModels.Suppliers;

namespace NeedleWork.Application.Features.Suppliers.Queries.GetAll;

public record GetAllSuppliersQuery() : IRequest<List<SupplierViewModel>>;