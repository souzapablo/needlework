namespace NeedleWork.Application.ViewModels.Products;

public record ProductDetailsViewModel(
    long Id,
    string Description,
    decimal Price,
    long SupplierId,
    string Supplier);
