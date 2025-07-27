using polimark.core.ConnectionSwagger;
using PoliMark.infraestructure.Service;

namespace polimark.api.Dependecy
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        { 
            services.AddTransient<IPoliMark, polimark.core.ConnectionSwagger.PoliMark>();
            services.AddTransient<ILoginService, LoginService>();
            return services;
        }
    }
}
