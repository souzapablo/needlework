using Microsoft.EntityFrameworkCore;
using NeedleWork.Core.Entities;
using System.Reflection;

namespace NeedleWork.Infrastructure;

public class NeedleWorkDbContext : DbContext
{
    public NeedleWorkDbContext(DbContextOptions<NeedleWorkDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<Supplier> Suppliers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
