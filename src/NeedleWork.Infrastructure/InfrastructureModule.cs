using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeedleWork.Infrastructure.Persistence;

namespace NeedleWork.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        
        return services;
    }   

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("NeedleWorkCs");

        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentNullException("ConnectionString");

        services.AddDbContext<NeedleWorkDbContext>(options => 
            options.UseSqlServer(connectionString));

        return services;
    }
}