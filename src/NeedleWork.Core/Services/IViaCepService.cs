using NeedleWork.Infrastructure.Models;

namespace NeedleWork.Core.Services;

public interface IViaCepService
{
    Task<ViaCepAddress?> GetAddressAsync(string cep);
}