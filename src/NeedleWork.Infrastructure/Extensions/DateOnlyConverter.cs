using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace NeedleWork.Infrastructure.Extensions;

public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter()
        : base(dateOnly =>
                dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime))
    { }
}