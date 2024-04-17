using System.Net.WebSockets;
using Client.Entities.Websockets;
using Client.Entities.Websockets.Payloads;
using Client.Handlers.Websockets.Send.Interfaces;
using Domain.Entities.Payloads.Dispatch;

namespace Client.Handlers.Websockets.Send;
public class PayloadSendHandler
: IPayloadSendHandler
{
    public PayloadSendHandler()
    {
    }

    public Task Handle(UserConnection ws, ArraySegment<byte> buffer)
    {
        Console.WriteLine("PayloadSendHandler.Handle");
        if (ws.ws.State != WebSocketState.Open)
        {
            Console.WriteLine(
                "PayloadSendHandler.Handle: WebSocketState is not Open");
            ws.Destroyed = true;
            ws = null;
            return Task.CompletedTask;
        }
        return ws.ws.SendAsync(
            buffer,
            WebSocketMessageType.Binary,
            true,
            CancellationToken.None);
    }

    public Task Dispatch(Dispatch<object> data, UserConnection ws)
    {
        Console.WriteLine("PayloadSendHandler.Dispatch");
        var payload = data.Serialize();
        return Handle(ws, payload);
    }

    public Task Heartbeat(UserConnection ws)
    {
        Console.WriteLine("PayloadSendHandler.Heartbeat");
        return Handle(ws, PayloadHeartbeat.Payload);
    }

    public Task Identify(UserConnection ws)
    {
        Console.WriteLine("PayloadSendHandler.Identify");
        if (ws.IdentifyPayloadUser == null)
        {
            Console.WriteLine(
                    "PayloadSendHandler.Identify: IdentifyPayloadUser is null");
            return Task.CompletedTask;
        }

        return Handle(ws, ws.IdentifyPayloadUser.Value);
    }
}
