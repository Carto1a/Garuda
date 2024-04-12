using Server.Services;
using Server.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<
    IWebsocketService,
    WebsocketService>();

var app = builder.Build();

app.UseWebSockets();
app.UseHttpsRedirection();
app.MapControllers();

await app.RunAsync();
