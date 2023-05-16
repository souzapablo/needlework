using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NeedleWork.Application.Behaviors;
using NeedleWork.Application.Features.Suppliers.Queries.GetAll;
using NeedleWork.Application.Validators.Suppliers;

namespace NeedleWork.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblyContaining(typeof(GetAllSuppliersQuery)))
            .AddValidators()
            .AddPipelineBehaviors();

        return services;
    }

    private static IServiceCollection AddPipelineBehaviors(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorPipelineBehavior<,>));

        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services
            .AddFluentValidationClientsideAdapters();
        services
            .AddValidatorsFromAssemblyContaining<CreateSupplierCommandValidator>();

        return services;
    }
}
