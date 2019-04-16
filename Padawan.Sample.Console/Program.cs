using System;

using Padawan.Resolver;
using Padawan.Sample.Console.Classes;
using Padawan.Sample.Console.Jobs;
using Microsoft.Extensions.DependencyInjection;

namespace Padawan.Sample.Console
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
