using MediatR;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Repositories;
using NeedleWork.Core.Shared;

namespace NeedleWork.Application.Features.Purchases.Commands.Create;
public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, long>
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;

    public CreatePurchaseCommandHandler(IPurchaseRepository purchaseRepository, IProductRepository productRepository, IUserRepository userRepository)
    {
        _purchaseRepository = purchaseRepository;
        _productRepository = productRepository;
        _userRepository = userRepository;
    }

    public async Task<long> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    {
        bool userExists = await _userRepository.VerifyIfExists(request.UserId);

        if (!userExists)
            throw new NotFoundException(Errors.UserNotFound(request.UserId));

        Purchase purchase = new(request.UserId, request.PurchaseDate);

        Product? product = await _productRepository.GetByIdAsync(request.ProductId);

        if (product is null)
            throw new NotFoundException(Errors.ProductNotFound(request.ProductId));

        PurchaseItem purchaseItem = new(product, request.Quantity);

        purchase.AddItem(purchaseItem);

        await _purchaseRepository.CreateAsync(purchase);

        return purchase.Id;
    }
}
