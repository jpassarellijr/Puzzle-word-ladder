using Microsoft.Extensions.DependencyInjection;
using Puzzle.Infra.CrossCutting.IoC;
using System;

namespace Puzzle.Services.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        /// <summary>
        /// Adds the dependency injection configuration.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <exception cref="System.ArgumentNullException">services</exception>
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}