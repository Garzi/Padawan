using Initium.Startup;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Initium.Abstractions;
using System;

namespace Initium.Extensions
{
    public static class WebHostBuilderExtensions
    {


        public static IWebHostBuilder UseInitium<TStartup>(this IWebHostBuilder hostBuilder, string applicationName = null) where TStartup : class
        {

            var startupName = typeof(TStartup).GetTypeInfo().Assembly.GetName().Name;
            
            hostBuilder.UseSetting(WebHostDefaults.ApplicationKey, applicationName ?? startupName);

            hostBuilder.ConfigureServices(collection =>
            {
                // Register initium services by attributes
                collection.RegisterAttributes();

                // Register initium configurations by attributes
                collection.RegisterConfigurationAttributes();

                // Add configured application & Configurition of using of initium application 
                collection.AddTransient<IStartupFilter, StartupFilter>();
            });

            hostBuilder.UseStartup(startupName);

            return hostBuilder;
        }
    }
}
