using JiuJitsuRecords.Application.Interfaces;
using JiuJitsuRecords.Application.Services;
using JiuJitsuRecords.Domain.Repositories;
using JiuJitsuRecords.Domain.Services;
using JiuJitsuRecords.Infraestructure.Repositories;
using JiuJitsuRecords.Infraestructure.Services;

namespace JiuJitsuRecords.WebAPI
{
    public static class DependencyInjectionConfigExtension
    {
        public static void ConfigureApplicationDependencies(this IServiceCollection services)
        {
            // Repositories
            services.AddSingleton<IAthleteRepository, AthleteRepository>(); // NOTA: criado como singleton pois estamos utilizando os dados em memória
            services.AddSingleton<IPositionRepository, PositionRepository>();

            // Services
            services.AddTransient<IJiujitsuAthleteService, JiujitsuAthleteService>();
            services.AddTransient<IPositionService, PositionService>();
        }
    }
}
