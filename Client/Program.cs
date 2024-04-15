using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Domain.Entities.Payloads;
using Domain.Entities.Payloads.Invoke;
using Domain.Enums.Payloads;

using var ws = new ClientWebSocket();

Console.Write("Coloque o seu username: ");
var username = Console.ReadLine() ?? "anonymous";
Console.WriteLine($"Username: {username}");

await ws.ConnectAsync(new Uri("ws://localhost:5281/ws"), CancellationToken.None);
var buffer = new byte[1024];

var indentifyPayload = IdentifyPayload
    .Create(username, "email", "password");

var heartbeatPayload = new Payload<object>(
    OpCodes.Heartbeat,
    null,
    null);

if (ws.State == WebSocketState.Open)
    await ws.SendAsync(
        indentifyPayload.Serialize(),
        WebSocketMessageType.Binary,
        true,
        CancellationToken.None);

Timer timer = new Timer(_ =>
{
    if (ws.State == WebSocketState.Open)
        ws.SendAsync(
            heartbeatPayload.Serialize(),
            WebSocketMessageType.Binary,
            true,
            CancellationToken.None);
}, null, 0, 41000);

while (ws.State == WebSocketState.Open)
{

    var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
    if (result.MessageType == WebSocketMessageType.Close)
        await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
    else
        Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, result.Count));
}

