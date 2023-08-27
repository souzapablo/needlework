namespace NeedleWork.Core.Shared;

public static class Errors
{
    public static string SupplierNotFound(long id) => 
        string.Format("Supplier with id {0} not found", id);
}