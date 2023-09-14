namespace NeedleWork.Application.ViewModels.Purchases;
public record PurchaseItemViewModel(
    string Product,
    decimal Quantity,
    decimal Price);