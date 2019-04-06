using System;
using Initium.Abstractions;
using Initium.Extensions;
using Initium.Sample.Console.Web;
using Initium.Sample.Web.Configuration;
using Initium.Sample.Web.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Initium.Sample.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            var apple = app.ApplicationServices.GetService<Apple>();

            var job = app.ApplicationServices.GetService<SchedulerJob>();

            var config = app.ApplicationServices.GetService<AppConfiguration>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
