using MediatR;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Repositories;
using NeedleWork.Core.Shared;

namespace NeedleWork.Application.Features.Products.Create;

public class CreateProductCommandHander : IRequestHandler<CreateProductCommand, long>
{
    private readonly IProductRepository _productRepository;
    private readonly ISupplierRepository _supplierRepository;

    public CreateProductCommandHander(IProductRepository productRepository, ISupplierRepository supplierRepository)
    {
        _productRepository = productRepository;
        _supplierRepository = supplierRepository;
    }

    public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        bool isSupplierIdValid = await _supplierRepository.VerifyIfExists(request.SupplierId);

        if (!isSupplierIdValid)
            throw new NotFoundException(Errors.SupplierNotFound(request.SupplierId));

        Product product = new(request.SupplierId, request.Description, request.Price, request.UnitOfMeasurement);

        await _productRepository.CreateAsync(product);

        return product.Id;
    }
}