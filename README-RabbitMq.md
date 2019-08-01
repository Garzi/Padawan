# Padawan RabbitMq
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

Multiple RabbitMq using

> .UseRabbitMq("Rabbit1"),   .UseRabbitMq("Rabbit2")

# Appsettings

```javascript
{

  "RabbitMq": {
    //"Url": "rabbitmq://localhost:5672",
    "Nodes": [
      "10.1.1.1",
      "10.1.1.2",
      "10.1.1.3"
    ],
    "Username": "admin",
    "Password": "123345",
    "DelayedExchangeMessageScheduler": false,
    "ConcurrentMessageLimit": 0,
    "RetryPolicy": {
      "Incremental": {
        "RetryLimit": 3,
        "InitialInterval": 500,
        "IntervalIncrement": 500
      }
    },
    "CircuitBreaker": {
      "TrackingPeriod": 5,
      "TripThreshold": 15,
      "ActiveThreshold": 10,
      "ResetInterval": 5
    },
    "RateLimiter": {
      "RateLimit": 10,
      "Interval": 60
    }
  }
}
```

