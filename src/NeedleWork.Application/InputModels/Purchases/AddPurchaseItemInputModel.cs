namespace NeedleWork.Application.InputModels.Purchases;

public record AddPurchaseItemInputModel(
    long ProductId,
    decimal Quantity
);
