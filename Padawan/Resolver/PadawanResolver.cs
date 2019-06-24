using System;
using Padawan.Extensions;
using Padawan.Startup;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Padawan.Resolver
{
    public class PadawanResolver : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public PadawanResolver()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.RegisterAttributes();
            serviceCollection.RegisterConfigurationAttributes();
            serviceCollection.RegisterSchedulerJobAttributes();

            ServiceProvider = serviceCollection.BuildServiceProvider();


            ServiceProvider.InitializeSchedulerJob();

        }

        public IServiceProvider ServiceProvider { get; set; }

        public void Dispose()
        {

        }
    }
}
