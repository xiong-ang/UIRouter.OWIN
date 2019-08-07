# UIRouter for OWIN
> A OWIN middleware for hosting static files and log webapi.

## Usage
This is a OWIN middlware, so we need to create startup class.
```C#
[assembly: OwinStartup(typeof(Demo.Simple.Startup))]

public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        app.UseUIRouter(new UIRouterConfig
        {
            // Config multiple maps between url router and file folder
            UIRouter = { 
                { "1/ui1", "UIs/ui1" },
                { "2/ui2", "UIs/ui2" },
                { "/", "UIs/ui2" }
            },
            // Config log webapi router
            LogRouter = "api/log",
            // Config log handler
            LogHandler = new MyLogHandler()
        });
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