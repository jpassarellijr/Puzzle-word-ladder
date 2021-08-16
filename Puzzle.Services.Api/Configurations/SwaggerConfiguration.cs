﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Puzzle.Services.Api.Configurations
{
    public static class SwaggerConfig
    {
        /// <summary>
        /// Adds the swagger configuration.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <exception cref="System.ArgumentNullException">services</exception>
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Puzzle Services API",
                    Description = "Service responsible for managing the Puzzle, its objects and actions.",
                    Contact = new OpenApiContact { Name = "Jose Passarelli Junior", Email = "jpassarellijr@gmail.com" },
                });
            });
        }

        /// <summary>
        /// Uses the swagger setup.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <exception cref="System.ArgumentNullException">app</exception>
        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}