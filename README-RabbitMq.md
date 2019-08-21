<p align="center">
    <a href="#Padawan">
        <img alt="logo" src="now-the-force-with-you.png">
    </a>
</p>


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
                 .UseRabbitMq("Rabbit1")
                 .UseRabbitMq("Rabbit2")
                .Build();
    }
```


Consumer Usage

```csharp
    [Consumer(QueueName = "QueueName", PrefetchCount = 2, ExchangeName = "ExchangeName")]
    public class SaveStockWhenEventReceived : IConsumer<StockEvent>
    {


        public async Task Consume(ConsumeContext<StockEvent> context)
        {
         

        }
    }
```


Consumer Usage

```csharp
    [Scoped]
    public class StockService
    {

        private readonly IBusProvider _busProvider;

        public StockService(IBusProvider busProvider)
        {

            _busProvider = busProvider;
        }


        public async Task Send()
        {

            await _busProvider.GetInstance()
                .Send<StockEvent>(new StockEvent() { }, "QueueName");

        }

    }
```

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

