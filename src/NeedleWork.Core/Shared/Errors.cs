namespace NeedleWork.Core.Shared;

public static class Errors
{
    public static string SupplierNotFound(long id) => 
        string.Format("Supplier with id {0} not found", id);

    public static string ProductNotFound(long id) => 
        string.Format("Product with id {0} not found", id);

    public static string UserNotFound(long id) => 
        string.Format("User with id {0} not found", id);
    public static string PurchaseNotFound(long id) =>
        string.Format("Purchase with id {0} not found", id);
    
    public static string PurchaseItemAlreadyPresent(string product) =>
        string.Format("{0} already present in purchase list", product);

    public static string AddressNotFound(string cep) =>
        string.Format("Address with CEP {0} not found", cep);
}