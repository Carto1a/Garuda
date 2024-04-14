using System.Net.WebSockets;
using Domain.Entities.Payloads;
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

    public Task Disconnect(WebSocket ws)
    {
        Console.WriteLine("PayloadHandler.Disconnect");
        return Task.CompletedTask;
    }

    public Task Heartbeat(WebSocket ws, int heartbeatInterval)
    {
        Console.WriteLine("PayloadHandler.Heartbeat");
        Timer timer = new Timer(_ =>
        {
            Handle(ws, PayloadHeartbeat.Payload);
        }, null, 0, heartbeatInterval);

        return Task.CompletedTask;
    }

    public Task HeartbeatAck(WebSocket ws)
    {
        Console.WriteLine("PayloadHandler.HeartbeatAck");
        return Handle(ws, PayloadHeartbeat.Payload);
    }

    public Task Hello(WebSocket ws)
    {
        Console.WriteLine("PayloadHandler.Hello");
        return Handle(ws, PayloadHello.Payload);
    }
}
