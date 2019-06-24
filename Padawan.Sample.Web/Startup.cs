
using System;
using Padawan.Sample.Web.Configuration;
using Padawan.Sample.Web.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Padawan.RabbitMq;
using Padawan.RabbitMq.Extensions;
using Padawan.RabbitMq.Provider;
using Padawan.Sample.Web.Classes;
using Padawan.Sample.Web.Consumer.Event;

namespace Padawan.Sample.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {

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
