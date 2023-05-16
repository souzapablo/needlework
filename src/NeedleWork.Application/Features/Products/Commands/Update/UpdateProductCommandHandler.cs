using MediatR;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Application.Features.Products.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id) ?? throw new Exception("Product not found");

        product.UpdateDescription(request.Description);
        product.UpdatePrice(request.Price);

        await _productRepository.UpdateAsync(product);

        return Unit.Value;
    }
}
