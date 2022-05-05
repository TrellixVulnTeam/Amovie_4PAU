using Behaviour.Interfaces;
using Behaviour.Repositories;
using Behaviour.Services;

namespace Amovie.Configuration
{
    public static class ControllerConfig
    {
        public static IServiceCollection RegisterControllers(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IReviewService, ReviewService>();

            return services;
        }
    }
}