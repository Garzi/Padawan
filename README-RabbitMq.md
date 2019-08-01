# Padawan
RabbitMq client for Padawan. Attribute using and registration of consumer


## Installation

```shell
PM> Install-Package Padawan.RabbitMq 
```

or

```shell
> dotnet add package Padawan.RabbitMq 
```

# Usage

Modify the Program.cs to apply the Padawan
```csharp
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
                .UseRabbitMq()
                .Build();
    }
```
