using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NeedleWork.Core.Enums;

namespace NeedleWork.Infrastructure.Extensions;

public class UserRoleConverter : ValueConverter<UserRole, string>
{
    public UserRoleConverter()
        : base(
            v => Enum.GetName(typeof(UserRole), v) ?? string.Empty,
            v => (UserRole) Enum.Parse(typeof(UserRole), v)
        )
    {
    }
}