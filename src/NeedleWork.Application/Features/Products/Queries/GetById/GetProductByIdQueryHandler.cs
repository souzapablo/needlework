using MediatR;
using NeedleWork.Application.ViewModels.Products;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Repositories;
using NeedleWork.Core.Shared;

namespace NeedleWork.Application.Features.Products.Queries.GetById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDetailsViewModel>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDetailsViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetByIdAsync(request.Id);

        if (product is null)
            throw new NotFoundException(Errors.ProductNotFound(request.Id));

        return new(product.Id,
            product.Supplier.Name,
            product.Description,
            product.Price,
            product.UnitOfMeasurement);
    }
}