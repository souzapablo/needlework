using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeedleWork.Core.Entities;

namespace NeedleWork.Infrastructure.Persistence.Configurations;

public class EmbroideryConfiguration : IEntityTypeConfiguration<Embroidery>
{
    public void Configure(EntityTypeBuilder<Embroidery> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasQueryFilter(e => !e.IsDeleted);
    }
}
