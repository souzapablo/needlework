using MediatR;
using NeedleWork.Application.ViewModels.Products;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;
using NeedleWork.Infrastructure.Shared;

namespace NeedleWork.Application.Features.Products.Queries.Get;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PagedList<ProductViewModel>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<PagedList<ProductViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        List<Product> products = await _productRepository.GetAsync(
            request.SearchTerm,
            request.SortColumn,
            request.SortOrder,
            request.Page,
            request.PageSize);

        List<ProductViewModel> supplierViewModels = products.Select(x => new ProductViewModel(
            x.Id,
            x.Description
        )).ToList();

        return PagedList<ProductViewModel>.Create(supplierViewModels, request.Page, request.PageSize);            
    }
}