using System.Net.WebSockets;
using Domain.Entities.Payloads;
using Domain.Entities.Payloads.Dispatch;
using Server.Entities.Websocket.Connections;
using Server.Entities.Websocket.Payloads;
using Server.Handlers.Websockets.Receive.Interfaces;
using Server.Handlers.Websockets.Send.Interfaces;

namespace Server.Handlers.Websockets.Send;
public class PayloadSendHandler
: IPayloadSendHandler
{
    public PayloadSendHandler()
    { }

    public Task Handle(WebSocket ws, ArraySegment<byte> payload)
    {
        Console.WriteLine("PayloadSendHandler.Handle");
        return ws.SendAsync(
            payload,
            WebSocketMessageType.Binary,
            true,
            CancellationToken.None);
    }

    public Task Dispatch(
        Dispatch<object> data, WebsocketConnection ws)
    {
        Console.WriteLine("PayloadSendHandler.Dispatch");
        var payload = data.Serialize();
        return Handle(ws.ws, payload);
    }

    public Task Disconnect(
        Dispatch<DisconnectedData> data, WebsocketConnection ws)
    {
        Console.WriteLine("PayloadSendHandler.Disconnect");
        var payload = data.Serialize();
        return Handle(ws.ws, payload);
    }

    public Task Heartbeat(WebsocketConnection ws)
    {
        Console.WriteLine("PayloadSendHandler.Heartbeat");
        ws.StartDisconnectTimer();
        return Handle(ws.ws, PayloadHeartbeat.Payload);
    }

    public Task HeartbeatAck(WebsocketConnection ws)
    {
        Console.WriteLine("PayloadSendHandler.HeartbeatAck");
        return Handle(ws.ws, PayloadHeartbeatAck.Payload);
    }

    public Task Hello(WebsocketConnection ws)
    {
        Console.WriteLine("PayloadSendHandler.Hello");
        return Handle(ws.ws, PayloadHello.Payload);
    }

    public Task InvalidSession(
        Payload<InvalidSessionPayload> data, WebsocketConnection ws)
    {
        Console.WriteLine("PayloadSendHandler.InvalidSession");
        return Handle(ws.ws, data.Serialize());
    }
}
