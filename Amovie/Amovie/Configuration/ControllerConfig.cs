using Behaviour;

namespace Amovie.Configuration
{
    public static class ControllerConfig
    {
        public static IServiceCollection RegisterControllers(this IServiceCollection services)
        {
            services.AddScoped<IMovieBehavior, MovieBehavior>();
            return services;
        }
    }
}