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

            if (startupName != "Startup")
                throw new ArgumentException("TStartup class must be registered as named as 'Startup'");


            hostBuilder.UseSetting(WebHostDefaults.ApplicationKey, applicationName ?? startupName);

            hostBuilder.ConfigureServices(collection =>
            {
                //collection.AddTransient<IStartupFilter, StartupFilter>();
            });

            hostBuilder.UseStartup(startupName);

            return hostBuilder;
        }
    }
}
