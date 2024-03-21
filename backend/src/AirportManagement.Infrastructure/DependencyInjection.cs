using System.Text;
using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Auth;
using AirportManagement.Application.Common.Interfaces.Persistence.Airports;
using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using AirportManagement.Application.Common.Interfaces.Persistence.Users;
using AirportManagement.Application.Common.Services;
using AirportManagement.Infrastructure.Airports.Persistence;
using AirportManagement.Infrastructure.Auth;
using AirportManagement.Infrastructure.Clients.Persistence;
using AirportManagement.Infrastructure.Common.Persistence;
using AirportManagement.Infrastructure.Services;
using AirportManagement.Infrastructure.Users.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AirportManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection serviceCollection,
        ConfigurationManager configurationManager)
    {
        serviceCollection.AddDbContext<AirportManagementDbContext>(
            options => options.UseSqlite("DataSource = AirportManagement.db"));


        serviceCollection.AddAuth(configurationManager);

        serviceCollection.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        serviceCollection.AddScoped<IAirportsRepository, AirportRepository>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IClientRepository, ClientRepository>();
        serviceCollection.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<AirportManagementDbContext>());
        return serviceCollection;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection serviceCollection,
        ConfigurationManager configurationManager)
    {
        var jwtSettings = new JwtSettings();
        configurationManager.Bind(JwtSettings.SectionName, jwtSettings);

        serviceCollection.AddSingleton(Options.Create(jwtSettings));
        serviceCollection.AddSingleton<IJwtTokengenerator, JwtTokenGenerator>();

        serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)
                )
            }
        );

        return serviceCollection;
    }
}