using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeedleWork.Application.Abstractions;
using NeedleWork.Core.Repositories;
using NeedleWork.Core.Services;
using NeedleWork.Infrastructure.Authentication;
using NeedleWork.Infrastructure.Persistence;
using NeedleWork.Infrastructure.Persistence.Repositories;
using NeedleWork.Infrastructure.Persistence.Repositories.Interfaces;
using NeedleWork.Infrastructure.Services;

namespace NeedleWork.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration)
            .AddRepositories()
            .AddAuth()
            .AddCaching(configuration)
            .AddServices();

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

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.Decorate<ISupplierRepository, CachedSupplierRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IPurchaseRepository, PurchaseRepository>();
        services.AddTransient<ISqlConnectionFactory, SqlConnectionFactory>();

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(); 

        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IAuthService, AuthService>();
        
        return services;
    }

    private static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration configuration)
    {
        string conneciton = configuration.GetConnectionString("RedisCs")!;
        services.AddStackExchangeRedisCache(redisOptions => 
        {
            redisOptions.Configuration = conneciton;
        });
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IViaCepService, ViaCepService>();
        
        return services;
    }
}