using System.Net.WebSockets;
using Domain.Entities.Payloads;
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
        WebsocketConnection connection =
            new WebsocketConnection(
                _payloadSendHandler,
                _dispatchHandler,
                _authenticator,
                ws);

        await _payloadSendHandler.Hello(connection);

        while (ws.State == WebSocketState.Open)
        {

            var payload = await GetPayload(ws, connection.buffer);
            if (payload == null)
            {
                if(ws.State == WebSocketState.Aborted)
                {
                    Console.WriteLine("Connection aborted");
                    if (!connection.Destroyed)
                        await connection.Disconnect();
                    break;
                }
                var payloadInvalid = InvalidSessionCodes
                    .InvalidPayload;
                Console.WriteLine("Payload is null");
                await _payloadSendHandler.InvalidSession(
                    payloadInvalid,
                    connection);
                await connection.Disconnect();
                connection = null;
                break;
            }

            if (payload.MessageType == WebSocketMessageType.Binary)
            {
                var task = _payloadReceiveHandler.Handle(
                    connection.buffer, connection, payload);
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
