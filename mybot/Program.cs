using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.Listen(IPAddress.Any, 5099);
});
var app = builder.Build();

app.Use(async (context, next) =>
{
    using var reader = new StreamReader(context.Request.Body, Encoding.UTF8);
    var requestBody = await reader.ReadToEndAsync();
    Console.WriteLine(requestBody);
    await next();
});
app.Map("", (appBuilder) =>
{
    appBuilder.Run(async context =>
    {
        await context.Response.WriteAsync("ok");
    });
});
app.Run();