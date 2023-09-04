using System.Security.Cryptography;
using System.Text;
using NeedleWork.Application.Abstractions;

namespace NeedleWork.Infrastructure.Authentication;

public class AuthService : IAuthService
{
    public string HashPassword(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }

        return builder.ToString();
    }
}