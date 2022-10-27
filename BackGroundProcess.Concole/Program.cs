using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("GetProducts", client =>
{
    client.BaseAddress = new Uri("http://localhost:12739");
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();


app.Run();

