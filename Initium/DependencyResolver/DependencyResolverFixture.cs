using System;
using Initium.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Initium.DependencyResolver
{
   public class DependencyResolverFixture : IDisposable
   {
       /// <summary>
       /// 
       /// </summary>
       public DependencyResolverFixture()
       {
           var serviceCollection = new ServiceCollection();
            
           serviceCollection.RegisterAttributes();
           serviceCollection.RegisterConfigurationAttributes();

           ServiceProvider = serviceCollection.BuildServiceProvider();
       }

       public IServiceProvider ServiceProvider { get; set; }
        
       public void Dispose()
        {
          
        }
    }
}
