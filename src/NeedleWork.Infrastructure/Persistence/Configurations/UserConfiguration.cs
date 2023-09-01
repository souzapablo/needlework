using Microsoft.EntityFrameworkCore;
using NeedleWork.Core.Entities;

namespace NeedleWork.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
    }
}