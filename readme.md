# UIRouter.OWIN
[![Build status](https://ci.appveyor.com/api/projects/status/bpq3qe60xtap6pg1?svg=true)](https://ci.appveyor.com/project/xiong-ang/uirouter-owin)    

> A OWIN middleware for hosting static files and log webapi.

## Installation
-------------

UIRouter is available as a NuGet package. You can install it using the NuGet Package Console window:

```
PM> Install-Package UIRouter.OWIN
```

After installation, update your existing [OWIN Startup](http://www.asp.net/aspnet/overview/owin-and-katana/owin-startup-class-detection) file with the following lines of code. 

```csharp
public void Configuration(IAppBuilder app)
{
    app.UseUIRouter(new UIRouterConfig
    {
        // Config multiple maps between url router and file folder
        UIRouter = { 
            { "1/ui1", "UIs/ui1" }, //{url router, file folder}
            { "2/ui2", "UIs/ui2" }
        }
    });
}
```

## Usage
1. Host static files
```csharp
public void Configuration(IAppBuilder app)
{
    app.UseUIRouter(new UIRouterConfig
    {
        // Config multiple maps between url router and file folder
        UIRouter = { 
            { "1/ui1", "UIs/ui1" }, //{url router, file folder}
            { "2/ui2", "UIs/ui2" }
        }
    });
}
```

2. Host log webapi
```csharp
public void Configuration(IAppBuilder app)
{
    app.UseUIRouter(new UIRouterConfig
    {
        UIRouter = ...,
        
        // Optional, config log webapi router
        LogRouter = "api/log"
        // Default log handler will write to trace
    });
}
```

3. Custom log handler
```csharp
public void Configuration(IAppBuilder app)
{
    app.UseUIRouter(new UIRouterConfig
    {
        UIRouter = ...,
        LogRouter = ...,
        
        // Optional, config log handler
        LogHandler = new CustomedLogHandler()
    });
}
```

```C#
class CustomedLogHandler : ILogHandler
{
    public void Log(LoggingEvent loggingEvent)
    {
        Console.WriteLine($"{DateTime.Now} - {loggingEvent.Level} - {loggingEvent.Message}");
    }
}
```   
## Examples
### Console Example
This is a simple demo.
### WPF Example
This demo how to use UIRouter.OWIN in cefsharp application.
In this example, we could know:
1. Configure UIRouter
2. Intercept log request in cefsharp
3. Open cefsharp dev tools
