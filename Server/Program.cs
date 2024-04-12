using Server.Handlers.Websockets;
using Server.Handlers.Websockets.Intefaces;
using Server.Services;
using Server.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<
    IPayloadHandler,
    PayloadHandler>();

builder.Services.AddSingleton<
    IInvokeHandler,
    InvokeHandler>();

builder.Services.AddSingleton<
    IDispatchHandler,
    DispatchHandler>();

builder.Services.AddScoped<
    IWebsocketService,
    WebsocketService>();

var app = builder.Build();

app.UseWebSockets();
app.UseHttpsRedirection();
app.MapControllers();

await app.RunAsync();
