using AirportManagement.Application.Common.Services;
using AirportManagement.Application.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace AirportManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
        });

        services.AddAutoMapper(typeof(MappingProfile));

        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}