<p align="center">
    <a href="#Padawan">
        <img alt="logo" src="now-the-force-with-you.png">
    </a>
</p>

# Padawan
Padawan  .NET Core Rapid Development Tool &amp; Library


## Padawan Libraries

- [Padawan.RabbitMq ](https://github.com/Garzi/Padawan/blob/master/README-RabbitMq.md)


***

# Padawan Core


## Installation

```shell
PM> Install-Package Padawan
```

or

```shell
> dotnet add package Padawan
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
                .Build();
    }
```

## Usage of dependency injection

Singleton lifetime

```csharp
    [Singleton]
    public class Apple
    {

        public string Value => "Apple";
    }
```

Singleton lifetime

```csharp
    [Singleton]
    public class Apple
    {

        public string Value => "Apple";
    }
```


Transient lifetime

```csharp
    [Transient]
    public class Banana
    {
        public string Value => "Banana";
    }
```

Scoped lifetime

```csharp
    [Scoped]
    public class Pear
    {
        public string Value => "Pear";
    }
```
## Configuration

Bind configuration to a class 
```csharp
    [Configuration("AppConfiguration")]
    public class AppConfiguration
    {
        public string Say { get; set; }
    }
```
    
## Job Configuration & Scheduling
The job configuration is handled in Scheduler Job Attribute classes. A job is a class that inherits ISchedulerJob

```csharp
 public class SchedulerJob : ISchedulerJob
   {

       private readonly Apple _apple;

       public SchedulerJob(Apple apple)
       {
           _apple = apple;
       }


        [RunNow]
        [RunEvery(10,Period.Second)]
        [RunEveryDayAt(5,12,12)] 
        [RunOnceAt(10,24)]
        [RunOnceIn(10, Period.Hour)]
        public void Run()
        {
            System.Console.WriteLine("Job is fired");
        }

    }
 ```
### Job Attributes

| Attribute | Description |
| ------ | ------ |
| RunNow |  Schedule a Job to run immediately |
| RunEvery |  Schedule a Job to run at an interval |
| RunEveryDayAt | Schedule a job to run at a specific time |
| RunOnceAt | Schedule a Job to run once at a specific time |
| RunOnceIn | Schedule a Job to run once at an interval |



## Dependencies & Referances

- https://github.com/fluentscheduler/FluentScheduler
- https://github.com/khellang/Scrutor
- https://github.com/JamesNK/Newtonsoft.Json
- https://github.com/ocinbat/Sillycore   (Thanks for the support @ocinbat)
