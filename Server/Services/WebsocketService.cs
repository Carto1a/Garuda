using System.Net.WebSockets;
using Server.Entities.Websocket.Connections;
using Server.Handlers.Websockets.Receive.Interfaces;
using Server.Handlers.Websockets.Send.Interfaces;
using Server.Services.Interfaces;

namespace Server.Services;
class WebsocketService
: IWebsocketService
{
    private readonly IPayloadSendHandler _payloadSendHandler;
    private readonly IPayloadReceiveHandler _payloadReceiveHandler;
    private readonly IDispatchHandler _dispatchHandler;
    private readonly IAuthenticatorService _authenticator;

    public WebsocketService(
        IPayloadSendHandler payloadSendHandler,
        IPayloadReceiveHandler payloadReceiveHandler,
        IDispatchHandler dispatchHandler,
        IAuthenticatorService authenticator)
    {
        _payloadSendHandler = payloadSendHandler;
        _payloadReceiveHandler = payloadReceiveHandler;
        _dispatchHandler = dispatchHandler;
        _authenticator = authenticator;
    }

    public async Task OpenWebsocket(WebSocket ws)
    {
        var buffer = new byte[1024];
        WebsocketConnection connection =
            new WebsocketConnection(
                _payloadSendHandler,
                _dispatchHandler,
                _authenticator,
                ws);

        while (ws.State == WebSocketState.Open)
        {
            await _payloadSendHandler.Hello(connection);

            var payload = await GetPayload(ws, buffer);
            // TODO: payload error or disconnect?
            if (payload == null)
            {
                connection.Disconnect();
                break;
            }

            if (payload.MessageType == WebSocketMessageType.Binary)
            {
                var task = _payloadReceiveHandler.Handle(buffer, connection);
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
