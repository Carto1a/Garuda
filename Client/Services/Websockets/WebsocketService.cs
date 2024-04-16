using System.Net.WebSockets;
using System.Text;
using Client.Entities.Websockets;
using Client.Services.Intefaces;

namespace Client.Services;
public class WebsocketService
: IWebsocketService
{
    public Task Handle()
    {
        using var ws = new ClientWebSocket();
        ws.ConnectAsync(
            new Uri("ws://localhost:5281/ws"), CancellationToken.None).Wait();

        var user = new UserConnection(Guid.NewGuid(), ws);

        while (ws.State == WebSocketState.Open)
        {
            var payload = GetPayload(ws, user.Buffer).Result;
            if (payload == null)
            {
                if (ws.State == WebSocketState.Aborted)
                {
                    Console.WriteLine("Connection aborted");
                    break;
                }
                Console.WriteLine("Payload is null");
                break;
            }
        }

        return Task.CompletedTask;
    }

    public Task<WebSocketReceiveResult?> GetPayload(WebSocket ws, byte[] buffer)
    {
        throw new NotImplementedException();
    }
}
