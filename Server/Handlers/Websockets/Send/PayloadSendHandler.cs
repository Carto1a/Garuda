using System.Net.WebSockets;
using Domain.Entities.Payloads;
using Server.Entities.Websocket.Connections;
using Server.Entities.Websocket.Payloads;
using Server.Handlers.Websockets.Receive.Interfaces;
using Server.Handlers.Websockets.Send.Interfaces;

namespace Server.Handlers.Websockets.Send;
public class PayloadSendHandler
: IPayloadSendHandler
{
    private readonly IDispatchHandler _dispatchHandler;

    public PayloadSendHandler(
        IDispatchHandler dispatchHandler)
    {
        _dispatchHandler = dispatchHandler;
    }

    public Task Handle(WebSocket ws, ArraySegment<byte> payload)
    {
        Console.WriteLine("PayloadHandler.Handle");
        return ws.SendAsync(
            payload,
            WebSocketMessageType.Binary,
            true,
            CancellationToken.None);
    }

    public Task Dispatch(Payload<object> payload)
    {
        var data = payload.d?.ToString();
        if (data == null)
            throw new ArgumentNullException();

        return _dispatchHandler.Handle(data);
    }

    public Task Disconnect(WebsocketConnection ws)
    {
        Console.WriteLine("PayloadHandler.Disconnect");
        // TODO: broadcast disconnect
        // TODO: clear connection
        return Task.CompletedTask;
    }

    public Task Heartbeat(WebsocketConnection ws)
    {
        Console.WriteLine("PayloadHandler.Heartbeat");
        ws.StartDisconnectTimer();
        return Handle(ws.ws, PayloadHeartbeat.Payload);
    }

    public Task HeartbeatAck(WebsocketConnection ws)
    {
        Console.WriteLine("PayloadHandler.HeartbeatAck");
        return Handle(ws.ws, PayloadHeartbeatAck.Payload);
    }

    public Task Hello(WebsocketConnection ws)
    {
        Console.WriteLine("PayloadHandler.Hello");
        return Handle(ws.ws, PayloadHello.Payload);
    }
}
