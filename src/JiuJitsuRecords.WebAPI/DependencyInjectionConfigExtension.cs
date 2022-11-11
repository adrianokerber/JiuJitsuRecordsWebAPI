using JiuJitsuRecords.Domain.Repositories;
using JiuJitsuRecords.Domain.Services;
using JiuJitsuRecords.WebAPI.Repositories;
using JiuJitsuRecords.WebAPI.Services;

namespace JiuJitsuRecords.WebAPI
{
    public static class DependencyInjectionConfigExtension
    {
        public static void ConfigureApplicationDependencies(this IServiceCollection services)
        {
            // Repositories
            services.AddSingleton<IAthleteRepository, AthleteRepository>(); // NOTA: criado como singleton pois estamos utilizando os dados em memória

            // Services
            //services.AddTransient<IJiujitsuAthleteService, JiujitsuAthleteService>();
        }
    }
}
