﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeedleWork.Core.Entities;

namespace NeedleWork.Infrastructure.Persistence.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}
