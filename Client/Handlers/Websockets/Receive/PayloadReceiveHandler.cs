using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Client.Entities.Websockets;
using Client.Handlers.Websockets.Receive.Interfaces;
using Domain.Entities.Payloads;

namespace Client.Handlers.Websockets.Receive;
public class PayloadReceiveHandler
: IPayloadReceiveHandler
{
    private readonly IList<Func<Payload<object>, UserConnection, Task>> _ops;

    public PayloadReceiveHandler()
    {
        _ops = new List<Func<Payload<object>, UserConnection, Task>>
        {
            Invoke,
            Heartbeat,
            null,
            Hello,
            HeartbeatAck,
            InvalidSession,
            null,
        };
    }

    public Task Handle(
        byte[] payload,
        UserConnection ws,
        WebSocketReceiveResult payloadInfo)
    {
        Console.WriteLine("PayloadReceiveHandler.Handle");
        var payloadString = Encoding.UTF8.GetString(
            payload.Take(payloadInfo.Count).ToArray());
        Console.WriteLine(
            $"Received message: {payloadString}");
        var payloadObject = JsonSerializer
            .Deserialize<Payload<object>>(payloadString);
        if (payloadObject == null)
            throw new ArgumentNullException();

        var op = payloadObject.op;
        var handler = _ops[(int)op];
        if (handler == null)
            throw new ArgumentNullException();
        return handler(payloadObject, ws);
    }

    public Task Invoke(Payload<object> payload, UserConnection ws)
    {
        Console.WriteLine("PayloadReceiveHandler.Invoke");
        return Task.CompletedTask;
    }

    public Task Heartbeat(Payload<object> payload, UserConnection ws)
    {
        Console.WriteLine("PayloadReceiveHandler.Heartbeat");
        return Task.CompletedTask;
    }

    public Task HeartbeatAck(Payload<object> payload, UserConnection ws)
    {
        Console.WriteLine("PayloadReceiveHandler.HeartbeatAck");
        return Task.CompletedTask;
    }

    public Task Hello(Payload<object> payload, UserConnection ws)
    {
        Console.WriteLine("PayloadReceiveHandler.Hello");
        return Task.CompletedTask;
    }

    public Task InvalidSession(Payload<object> payload, UserConnection ws)
    {
        Console.WriteLine("PayloadReceiveHandler.InvalidSession");
        return Task.CompletedTask;
    }
}
