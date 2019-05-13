using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Padawan.Extensions;

namespace Padawan.Sample.Web
{
    public class Program
    {

        public static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UsePadawan<Startup>("Padawan.Sample.Web")
                .Build();
    }
}
