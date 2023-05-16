using MediatR;
using NeedleWork.Application.ViewModels.Products;
using NeedleWork.Core.Models;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Application.Features.Products.Queries.GetAll;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PaginationResult<ProductViewModel>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<PaginationResult<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(request.Description, request.Page, request.PageSize);

        return new PaginationResult<ProductViewModel>()
        {
            ItemsCount = products.ItemsCount,
            Page = products.Page,
            PageSize = products.PageSize,
            TotalPages = products.TotalPages,
            Data = products.Data.Select(p => new ProductViewModel(
                p.Id, p.Description, p.Price, p.Supplier.Name))
        };
    }
}
