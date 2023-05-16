using Microsoft.Extensions.DependencyInjection;
using NeedleWork.Application.Features.Suppliers.Queries.GetAll;

namespace NeedleWork.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblyContaining(typeof(GetAllSuppliersQuery)));

        return services;
    }
}
