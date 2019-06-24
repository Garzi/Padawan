using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using FluentScheduler;
using Padawan.Extensions;

namespace Padawan.Startup
{
    public class StartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
               
                // Get configuration
                var configureation =  builder.ApplicationServices.GetService<IConfiguration>();


                // Invoke padawan actions
                foreach (var action in Padawan.StartupAction)
                {
                    action.Invoke(builder);
                }


                // On application start
                var appLifetime = builder.ApplicationServices.GetService<IApplicationLifetime>();

                appLifetime.ApplicationStarted.Register(() =>
                {
                    builder.ApplicationServices.InitializeSchedulerJob();

                });
                appLifetime.ApplicationStopped.Register(() =>
                {
                    JobManager.StopAndBlock();
                });

                
                next(builder);
            };
        }
        
   
    }
}
