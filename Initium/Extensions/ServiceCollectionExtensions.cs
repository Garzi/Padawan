using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Initium.Extensions
{
  public  static class ServiceCollectionExtensions
    {

        public static IServiceProvider UseInitium(this IServiceCollection serviceCollection)
        {
            return new ServiceProvider(serviceCollection);
        }
    }
}
