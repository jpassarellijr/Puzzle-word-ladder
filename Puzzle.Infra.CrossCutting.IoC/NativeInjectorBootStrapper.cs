using Microsoft.Extensions.DependencyInjection;
using Puzzle.Application.Interfaces;
using Puzzle.Application.Services;
using Puzzle.Infra.Data.Interfaces;
using Puzzle.Infra.Data.Services;

namespace Puzzle.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IWordDictionaryService, WordDictionaryService>();
            services.AddScoped<Puzzle.Application.Interfaces.IWordLadderService, Puzzle.Application.Services.WordLadderService>();

            // Domain
            services.AddScoped<Domain.Interfaces.IWordLadderService, Domain.Services.WordLadderService>();

            // Data
            services.AddScoped<IWordDictionaryServiceApi, WordDictionaryServiceApi>();
        }
    }
}