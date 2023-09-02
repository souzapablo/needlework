namespace NeedleWork.Core.Shared;

public static class Errors
{
    public static string SupplierNotFound(long id) => 
        string.Format("Supplier with id {0} not found", id);

    public static string ProductNotFound(long id) => 
        string.Format("Product with id {0} not found", id);

    public static string UserNotFound(long id) => 
        string.Format("User with id {0} not found", id);
}