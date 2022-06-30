using CommandPattern;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddCommandManagersDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICommandManager, CommandManager>();
            return services;
        }
    }
}
