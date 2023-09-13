using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeedleWork.Core.Entities;

namespace NeedleWork.Infrastructure.Persistence.Configurations;
public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasQueryFilter(x => x.IsActive);
    }
}
