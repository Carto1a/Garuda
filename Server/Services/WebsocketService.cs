using System.Net.WebSockets;
using System.Text;
using Server.Services.Interfaces;

namespace Server.Services;
class WebsocketService
: IWebsocketService
{
    public WebsocketService()
    {
    }

    public async Task OpenWebsocket(WebSocket ws)
    {
        var buffer = new byte[1024];
        while (ws.State == WebSocketState.Open)
        {
            var payload = await GetPayload(ws, buffer);
            if (payload == null)
                break;

            /* Console.WriteLine(Encoding.UTF8.GetString(buffer)); */
            /* /1* await webSocket.SendAsync( *1/ */
            /* /1*     Encoding.UTF8.GetBytes($"Hello, World! {DateTime.Now}"), *1/ */
            /* /1*     WebSocketMessageType.Text, *1/ */
            /* /1*     true, *1/ */
            /* /1*     CancellationToken.None); *1/ */
            /* /1* await Task.Delay(1000); *1/ */
            if (payload.MessageType == WebSocketMessageType.Binary)
            {
                var bin = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(
                    $"Received message: {bin}");

                // await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("Hello, World!")), WebSocketMessageType.Text, true, CancellationToken.None);
            }
            else if (payload.MessageType == WebSocketMessageType.Close)
            {
                Console.WriteLine("Received close message");
                await ws.CloseAsync(
                    WebSocketCloseStatus.NormalClosure,
                    string.Empty,
                    CancellationToken.None);
            }
        }
    }

    public async Task<WebSocketReceiveResult?> GetPayload(
        WebSocket ws,
        byte[] buffer)
    {
        try
        {
            /* var buffer = new byte[1024]; */
            var payload = await ws
                .ReceiveAsync(
                        new ArraySegment<byte>(buffer),
                        CancellationToken.None);

            return payload;
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
            return null;
        }
    }

}
