using Behaviour;
using Behaviour.Interfaces;
using Behaviour.Services;

namespace Amovie.Configuration
{
    public static class ControllerConfig
    {
        public static IServiceCollection RegisterControllers(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<INewsService, NewsService>();
            return services;
        }
    }
}