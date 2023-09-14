using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Enums;
using NeedleWork.Infrastructure.Extensions;

namespace NeedleWork.Infrastructure.Persistence;

public class NeedleWorkDbContext : DbContext
{
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<PurchaseItem> PurchaseItems { get; set; }
    public NeedleWorkDbContext(DbContextOptions<NeedleWorkDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<UnitOfMeasurement>()
            .HaveConversion<UnitOfMeasurementConverter>();

        configurationBuilder
            .Properties<UserRole>()
            .HaveConversion<UserRoleConverter>();

        configurationBuilder.Properties<decimal>()
            .HavePrecision(6, 2);

        configurationBuilder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");
    }
}