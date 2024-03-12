using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Auth;
using AirportManagement.Application.Common.Interfaces.Persistence.Airports;
using AirportManagement.Application.Common.Interfaces.Persistence.Users;
using AirportManagement.Application.Common.Services;
using AirportManagement.Infrastructure.Airports.Persistence;
using AirportManagement.Infrastructure.Auth;
using AirportManagement.Infrastructure.Common.Persistence;
using AirportManagement.Infrastructure.Services;
using AirportManagement.Infrastructure.Users.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirportManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        services.AddDbContext<AirportManagementDbContext>(
            options => options.UseSqlite("DataSource = AirportManagement.db"));

        services.Configure<JwtSettings>(builderConfiguration.GetSection(JwtSettings.SectionName));


        services.AddSingleton<IJwtTokengenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IAirportsRepository, AirportRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<AirportManagementDbContext>());
        return services;
    }
}