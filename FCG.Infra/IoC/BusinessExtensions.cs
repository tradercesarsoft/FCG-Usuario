using FCG.Business.Events;
using FCG.Business.Interfaces;
using FCG.Business.Services;
using FCG.Business.Services.Interfaces;
using FCG.Core.Communication.Mediator;
using FCG.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FCG.Infra.IoC;

/// <summary>
/// Extensões para configuração de serviços de negócio
/// </summary>
public static class BusinessExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        // Serviços de negócio
        services.AddScoped<IEventoService, EventoService>();
        services.AddScoped<IMediatorHandler, MediatrHandler>();
        services.AddMediatR(a => a.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AuthEventHandler>());

        return services;
    }
}