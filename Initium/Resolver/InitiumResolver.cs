using System;
using Initium.Extensions;
using Initium.Startup;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Initium.Resolver
{
   public class InitiumResolver : IDisposable
   {
       /// <summary>
       /// 
       /// </summary>
       public InitiumResolver()
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
