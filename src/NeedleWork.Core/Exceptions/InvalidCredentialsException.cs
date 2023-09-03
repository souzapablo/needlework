namespace NeedleWork.Core.Exceptions;

public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException()
        : base("Invalid e-mail or password")
    {
        
    }
}