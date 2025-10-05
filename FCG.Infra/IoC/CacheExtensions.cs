using FCG.Core.Communication.Mediator;
using FCG.Core.Services.Interfaces;
using FCG.Infra.Cache;
using Microsoft.Extensions.DependencyInjection;


namespace FCG.Infra.IoC;

public static class CacheExtensions
{
    public static IServiceCollection AddCacheServices(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<ICacheService, MemCacheService>();
        return services;
    }
}