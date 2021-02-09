using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smooth.Power.Logic.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smooth.Power.Logic.Injection
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddLogic(this IServiceCollection services, IConfiguration configuration)
        {
            Settings settings = new Settings();
            configuration.Bind(settings);
            Settings.DefaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddTransient<SmoothPowerContext>();
            new SmoothPowerContext().Database.EnsureCreated();
            return services;
        }
    }
}
