using System;
using FluentScheduler;
using Initium.Startup;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Newtonsoft.Json;

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

                // Register initium Scheduler job by attributes
                collection.RegisterSchedulerJobAttributes();

                // Add configured application & Configurition of using of initium application 
                collection.AddTransient<IStartupFilter, StartupFilter>();
            });

            hostBuilder.UseStartup(startupName);

            return hostBuilder;

        }


        /// <summary>
        /// Use Daylight Saving Time
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseUtcTime(this IWebHostBuilder hostBuilder) 
        {

            // Json Serializer Settings
            Initium.JsonSerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            //  FLuent Scheduler Timing
            JobManager.UseUtcTime();

            return hostBuilder;

        }

        /// <summary>
        /// Use Local Time
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseLocalTime(this IWebHostBuilder hostBuilder)
        {

            // Json Serializer Settings
            Initium.JsonSerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            

            return hostBuilder;

        }


        /// <summary>
        /// Configure Initium Json Option
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <param name="options">Newtonsoft Json Serializer Settings</param>
        /// <returns></returns>
        public static IWebHostBuilder ConfigureInitiumJsonOption(this IWebHostBuilder hostBuilder, Action<JsonSerializerSettings> options)
        {

            options.Invoke(Initium.JsonSerializerSettings);


            return hostBuilder;

        }
    }
}

