using AsynchronousProgramming.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsynchronousProgramming
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddAsyncDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAsyncMicrosoftService, AsyncMicrosoftService>();

            return services;
        }
    }
}
