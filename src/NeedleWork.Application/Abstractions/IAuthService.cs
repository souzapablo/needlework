namespace NeedleWork.Application.Abstractions;

public interface IAuthService
{
     string HashPassword(string password);
}