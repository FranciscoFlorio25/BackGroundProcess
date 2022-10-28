using Microsoft.Net.Http.Headers;
using Serilog.Formatting.Compact;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("GetProducts", client =>
{
    client.BaseAddress = new Uri("http://localhost:12739");
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

var logger = new LoggerConfiguration()
    //.ReadFrom.Configuration(builder.Configuration)
    //.WriteTo.Console()
    .WriteTo.File(new RenderedCompactJsonFormatter(), "../logs/log.json", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();


app.Run();

