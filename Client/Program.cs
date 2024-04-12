using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Domain.Entities.Payloads;
using Domain.Entities.Payloads.Invoke;
using Domain.Enums.Payloads;

using var ws = new ClientWebSocket();
await ws.ConnectAsync(new Uri("ws://localhost:5281/ws"), CancellationToken.None);

Console.Write("Coloque o seu username: ");
var username = Console.ReadLine() ?? "anonymous";

var buffer = new byte[1024];

string jsonString = JsonSerializer.Serialize(new Payload<Join>
(
    OpCodes.Invoke,
    new Join(
        Guid.NewGuid()
    )
));

await ws.SendAsync(
    Encoding.UTF8.GetBytes(jsonString),
    WebSocketMessageType.Binary,
    true,
    CancellationToken.None);

while (ws.State == WebSocketState.Open)
{
    /* var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None); */
    /* Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, result.Count)); */
    var result = await ws.ReceiveAsync(buffer, CancellationToken.None);
    if (result.MessageType == WebSocketMessageType.Close)
        await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
    else
        Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, result.Count));
}

