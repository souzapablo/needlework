using MediatR;
using NeedleWork.Application.ViewModels.Products;
using NeedleWork.Core.Repositories;

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
        var product = await _productRepository.GetByIdAsync(request.Id, p => p.Supplier);

        if (product is null)
            throw new Exception("Product not found");

        return new ProductDetailsViewModel(
            product.Id,
            product.Description,
            product.Price,
            product.SupplierId,
            product.Supplier.Name);
    }
}
