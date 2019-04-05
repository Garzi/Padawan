using System;
using System.Collections.Generic;
using System.Text;
using Initium.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Initium.Startup
{
   public class Startup : IStartup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            


            return services.UseInitium();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) => { await context.Response.WriteAsync("Hello World!"); });
        }
    }
}
