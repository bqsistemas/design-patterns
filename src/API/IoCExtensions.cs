using API.Services;
using API.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddAPIDependencies(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ILearnerService, LearnerService>();

            return services;
        }
    }
}
