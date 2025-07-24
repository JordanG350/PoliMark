using maasapp.infrastructure.Data;

namespace maasapp.api.Dependecy
{
    public static class dataServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            //dependencia para bases de datos
            services.AddScoped<IconnectionPostgresql, connectionPostgresql> ();
            return services;
        }

    }
}
