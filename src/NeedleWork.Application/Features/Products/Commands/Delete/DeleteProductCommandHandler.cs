using MediatR;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Application.Features.Products.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id) ?? throw new Exception("Product not found");

        product.Delete();

        await _productRepository.UpdateAsync(product);

        return Unit.Value;
    }
}
