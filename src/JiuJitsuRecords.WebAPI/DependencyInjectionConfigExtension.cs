using JiuJitsuRecords.Domain.Services;
using JiuJitsuRecords.WebAPI.Services;

namespace JiuJitsuRecords.WebAPI
{
    public static class DependencyInjectionConfigExtension
    {
        public static void ConfigureApplicationDependencies(this IServiceCollection services)
        {
            // Repositories
            // TODO: add data repository here!

            // Services
            services.AddTransient<IJiujitsuAthleteService, JiujitsuAthleteService>();
        }
    }
}
