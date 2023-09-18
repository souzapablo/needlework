namespace NeedleWork.Core.Exceptions;

public class PurchaseItemAlreadyPresentException : Exception
{
    public PurchaseItemAlreadyPresentException(string message)
        :base(message)
    {
        
    }
}