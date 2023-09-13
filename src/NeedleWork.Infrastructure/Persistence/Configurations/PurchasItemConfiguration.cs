using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeedleWork.Core.Entities;

namespace NeedleWork.Infrastructure.Persistence.Configurations;
public class PurchasItemConfiguration : IEntityTypeConfiguration<PurchaseItem>
{
    public void Configure(EntityTypeBuilder<PurchaseItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasQueryFilter(x => x.IsActive);

        builder.HasOne(x => x.Product)
            .WithOne();
    }
}
