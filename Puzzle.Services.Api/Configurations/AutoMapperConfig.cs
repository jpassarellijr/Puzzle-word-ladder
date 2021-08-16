using Microsoft.Extensions.DependencyInjection;
using Puzzle.Application.Mapping;
using System;

namespace Puzzle.Services.Api.Configurations
{
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Adds the automatic mapper configuration.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <exception cref="System.ArgumentNullException">services</exception>
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}