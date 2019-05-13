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
            var resolver = new PadawanResolver();

            var app = resolver.ServiceProvider.GetService<App>();
            
            app.Run();
           

            System.Console.ReadLine();

        }
    }
}
