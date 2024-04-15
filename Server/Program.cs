using Server.Handlers.Websockets.Receive;
using Server.Handlers.Websockets.Receive.Interfaces;
using Server.Handlers.Websockets.Send;
using Server.Handlers.Websockets.Send.Interfaces;
using Server.Services;
using Server.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<
    IInvokeHandler,
    InvokeHandler>();

builder.Services.AddSingleton<
    IDispatchHandler,
    DispatchHandler>();

builder.Services.AddSingleton<
    IPayloadSendHandler,
    PayloadSendHandler>();

builder.Services.AddSingleton<
    IPayloadReceiveHandler,
    PayloadReceiveHandler>();

builder.Services.AddSingleton<
    IAuthenticatorService,
    AuthenticatorService>();

builder.Services.AddScoped<
    IWebsocketService,
    WebsocketService>();

var app = builder.Build();

app.UseWebSockets();
app.UseHttpsRedirection();
app.MapControllers();

await app.RunAsync();
