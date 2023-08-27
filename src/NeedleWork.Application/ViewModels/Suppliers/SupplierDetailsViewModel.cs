using NeedleWork.Application.ViewModels.Products;

namespace NeedleWork.Application.ViewModels.Suppliers;

public record SupplierDetailsViewModel(
    long Id,
    string Name,
    string Contact,
    List<ProductViewModel> Products
);