﻿
using Padawan.Sample.Web.Configuration;
using Padawan.Sample.Web.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Padawan.Sample.Web.Classes;

namespace Padawan.Sample.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            var apple = app.ApplicationServices.GetService<Apple>();

            var banana = app.ApplicationServices.GetService<Banana>();

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
