using GamersOn.Domain.Repositories;
using GamersOn.Domain.Services;
using GamersOn.Infrastructure.Common;
using GamersOn.Infrastructure.Persistense;
using GamersOn.Infrastructure.Persistense.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GamersOn.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("GamersOnDatabase");

        services.AddDbContext<GamersOnContext>(opt =>
        {
            opt.UseSqlServer(connectionString)
               .EnableSensitiveDataLogging()
               .LogTo(Console.Write, LogLevel.Information);
        });

        services.Configure<JwtTokenSettings>(configuration.GetSection(JwtTokenSettings.SectionName));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration.GetSection("JwtSettings:Issuer").Value,
                        ValidAudience = configuration.GetSection("JwtSettings:Audience").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings:Secret").Value))
                    };
                });

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPasswordHashService, PasswordHashService>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGameRepository, GameRepository>();

        return services;
    }
}
