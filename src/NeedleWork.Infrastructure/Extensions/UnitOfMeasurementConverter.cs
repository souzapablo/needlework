using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NeedleWork.Core.Enums;

namespace NeedleWork.Infrastructure.Extensions;

public class UnitOfMeasurementConverter : ValueConverter<UnitOfMeasurement, string>
{
    public UnitOfMeasurementConverter()
        : base(
            v => Enum.GetName(typeof(UnitOfMeasurement), v) ?? string.Empty,
            v => (UnitOfMeasurement) Enum.Parse(typeof(UnitOfMeasurement), v)
        )
    {
    }
}