using Microsoft.OpenApi.Models;

namespace GamersOn.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentention(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddHttpContextAccessor();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "GamersON API",
                Description = "API para cadastro de games e avaliação",
                Contact = new OpenApiContact
                {
                    Name = "Diego Perillo",
                    Email = "sis.dperillo@gmail.com"
                }
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header usando o esquema Bearer."

            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        } ,
                        new string [] {}
                    }
                });

            options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        });

        return services;
    }
}