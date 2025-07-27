using polimark.infrastructure.Data;

namespace polimark.api.Dependecy
{
    public static class dataServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IconnectionSql, connectionSql> ();
            return services;
        }

    }
}
