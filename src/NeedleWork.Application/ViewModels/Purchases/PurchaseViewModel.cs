namespace NeedleWork.Application.ViewModels.Purchases;

public record PurchaseViewModel(
    long Id,
    decimal Total,
    DateTime PurchaseDate
);