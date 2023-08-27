namespace NeedleWork.Core.Exceptions;

public class InputValidationException : Exception
{
    public InputValidationException(IDictionary<string, string[]> errors)
    {
        Errors = errors;
    }

    public IDictionary<string, string[]> Errors { get; }
}