using FCG.Business.Interfaces;
using FCG.Infra.Data;
using FCG.Infra.Data.Repositories;
using FCG.Infra.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FCG.Infra.IoC;


/// <summary>
/// Extensões para configuração de serviços de dados
/// </summary>
public static class DataExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("FCG.Infra")));

        // Repositórios
        services.AddScoped<IEventoRepository, EventoRepository>();


        // DatabaseSeeder
        services.AddScoped<DatabaseSeeder>();

        return services;
    }
}