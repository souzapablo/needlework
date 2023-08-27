using Microsoft.EntityFrameworkCore;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Enums;
using NeedleWork.Infrastructure.Extensions;

namespace NeedleWork.Infrastructure.Persistence;

public class NeedleWorkDbContext : DbContext
{
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Product> Products { get; set; }
    public NeedleWorkDbContext(DbContextOptions<NeedleWorkDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Supplier>()
            .HasQueryFilter(x => x.IsActive);
        
        modelBuilder
            .Entity<Product>()
            .HasQueryFilter(x => x.IsActive);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<UnitOfMeasurement>()
            .HaveConversion<UnitOfMeasurementConverter>();

        configurationBuilder.Properties<decimal>()
            .HavePrecision(6, 2);
    }
}