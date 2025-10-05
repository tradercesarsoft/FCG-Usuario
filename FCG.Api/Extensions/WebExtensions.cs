using Asp.Versioning.ApiExplorer;
using FCG.Api.Configs;
using FCG.Api.Extensions;
using FCG.Core.Communication.Mediator;

namespace FCG.Api.Extensions;

/// <summary>
/// Extensões para configuração de serviços Web/API
/// </summary>
public static class WebExtensions
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Controllers, HttpContext, API Versioning, Swagger
        services.AddControllers();
        services.AddHttpContextAccessor();
        services.AddApiVersioningConfig();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerConfig();

        // Configurar versionamento do Swagger
        var serviceProvider = services.BuildServiceProvider();
        var apiVersionDescriptionProvider = serviceProvider.GetRequiredService<IApiVersionDescriptionProvider>();
        services.ConfigureSwaggerVersioning(apiVersionDescriptionProvider);


        return services;
    }
}