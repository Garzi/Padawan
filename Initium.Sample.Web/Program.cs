using Initium.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Initium.Sample.Web
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
                .UseInitium<Startup>("Initium.Sample.Web")
                .Build();
    }
}
