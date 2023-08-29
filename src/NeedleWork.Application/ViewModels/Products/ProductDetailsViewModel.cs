using NeedleWork.Core.Enums;

namespace NeedleWork.Application.ViewModels.Products;

public record ProductDetailsViewModel(
    long Id,
    string Supplier,
    string Description,
    decimal Price,
    UnitOfMeasurement UnitOfMeasurement
);