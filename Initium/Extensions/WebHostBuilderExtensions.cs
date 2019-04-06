using Initium.Startup;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Initium.Abstractions;
using System;
using System.Threading.Tasks;
using FluentScheduler;

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
        /// Daylight Saving Time
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseUtcTime(this IWebHostBuilder hostBuilder) 
        {

            //TODO : İmplement UtcDateTimeProvider


            //  FLuent Scheduler Timing
            JobManager.UseUtcTime();
            

   
            return hostBuilder;

        }

        
    }
}
