using System;

using Initium.Resolver;
using Initium.Sample.Console.Classes;
using Initium.Sample.Console.Jobs;
using Microsoft.Extensions.DependencyInjection;

namespace Initium.Sample.Console
{
    class Program
    {

        
        static void Main(string[] args)
        {
            var resolver = new InitiumResolver();

            var apple = resolver.ServiceProvider.GetService<Apple>();

            var job = resolver.ServiceProvider.GetService<SchedulerJob>();

            var raspberry = resolver.ServiceProvider.GetService<IRaspberry>();

            System.Console.ReadLine();

        }
    }
}
