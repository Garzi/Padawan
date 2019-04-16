# Padawan
Padawan  .NET Core Rapid Development Tool &amp; Library



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

Bind configuration to class and option<T>
```csharp
    [Configuration("AppConfiguration")]
    public class AppConfiguration
    {
        public string Say { get; set; }
    }
```
