using System.Net.WebSockets;
using Client.Entities.Websockets;
using Client.Entities.Websockets.Payloads;
using Client.Handlers.Websockets.Send.Interfaces;
using Domain.Entities.Payloads.Dispatch;

namespace Client.Handlers.Websockets.Send;
public class PayloadSendHandler
: IPayloadSendHandler
{
    public Task Handle(WebSocket ws, ArraySegment<byte> buffer)
    {
        Console.WriteLine("PayloadSendHandler.Handle");
        return ws.SendAsync(
            buffer,
            WebSocketMessageType.Binary,
            true,
            CancellationToken.None);
    }

    public Task Dispatch(Dispatch<object> data, UserConnection ws)
    {
        Console.WriteLine("PayloadSendHandler.Dispatch");
        var payload = data.Serialize();
        return Handle(ws.ws, payload);
    }

    public Task Disconnect(
        Dispatch<DisconnectedData> data, UserConnection ws)
    {
        Console.WriteLine("PayloadSendHandler.Disconnect");
        return Task.CompletedTask;
    }

    public Task Heartbeat(WebSocket ws)
    {
        Console.WriteLine("PayloadSendHandler.Heartbeat");
        return Handle(ws, PayloadHeartbeat.Payload);
    }

    public Task Identify(UserConnection ws)
    {
        Console.WriteLine("PayloadSendHandler.Identify");
        if (ws.IdentifyPayloadUser != null)
            return Handle(ws.ws, ws.IdentifyPayloadUser.Value);

        Console.WriteLine(
            "PayloadSendHandler.Identify: IdentifyPayloadUser is null");
        return Task.CompletedTask;
    }
}
