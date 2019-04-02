using System;
using System.Collections.Generic;
using System.Text;
using Initium.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Initium
{
    public class ServiceProvider : IServiceProvider
    {
        
        private readonly IServiceProvider _provider;

        public ServiceProvider(IServiceCollection serviceCollection)
        {

            // Register initium classes & attributes
            serviceCollection.RegisterAttributes();

            // Build sercice provider
            _provider = serviceCollection.BuildServiceProvider();
        }

        public object GetService(Type serviceType)
        {
            return _provider.GetService(serviceType);
        }
    }
}
