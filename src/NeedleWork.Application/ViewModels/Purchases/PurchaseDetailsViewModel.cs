namespace NeedleWork.Application.ViewModels.Purchases;
public record PurchaseDetailsViewModel(
    long Id,
    List<PurchaseItemViewModel> Items,
    decimal TotalPirce,
    DateTime PurchaseDate);
