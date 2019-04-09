using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Initium.Extensions;

namespace Initium.Startup
{
    public class StartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
               
                // Get configuration
                var configureation =  builder.ApplicationServices.GetService<IConfiguration>();
                
                // On application start
                var appLifetime = builder.ApplicationServices.GetService<IApplicationLifetime>();

                appLifetime.ApplicationStarted.Register(() =>
                {
                    builder.ApplicationServices.InitializeSchedulerJob();

                });
                appLifetime.ApplicationStopped.Register(() =>
                {

                });

                next(builder);
            };
        }
        
   
    }
}
