using maasapp.core.ConnectionSwagger;

namespace maasapp.api.Dependecy
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        { 
            services.AddTransient<IPoliMark, PoliMark>();
            return services;
        }
    }
}
