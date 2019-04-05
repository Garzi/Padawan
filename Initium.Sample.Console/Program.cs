using System;
using Initium.DependencyResolver;
using Initium.Sample.Console.Classes;

using Microsoft.Extensions.DependencyInjection;

namespace Initium.Sample.Console
{
    class Program
    {

        
        static void Main(string[] args)
        {
            var resolver = new DependencyResolverFixture();

            var apple = resolver.ServiceProvider.GetService<Apple>();

            var raspberry = resolver.ServiceProvider.GetService<IRaspberry>();

        }
    }
}
