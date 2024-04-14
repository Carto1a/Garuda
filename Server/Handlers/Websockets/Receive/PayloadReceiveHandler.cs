using System.Text;
using System.Text.Json;
using Domain.Entities.Payloads;
using Server.Handlers.Websockets.Receive.Interfaces;

namespace Server.Handlers.Websockets.Receive;
public class PayloadReceiveHandler
: IPayloadReceiveHandler
{
    private readonly IInvokeHandler _invokeHandler;
    private readonly IDispatchHandler _dispatchHandler;
    private readonly IList<Func<Payload<object>, Task>> _ops;

    public PayloadReceiveHandler(
        IInvokeHandler invokeHandler,
        IDispatchHandler dispatchHandler)
    {
        _invokeHandler = invokeHandler;
        _dispatchHandler = dispatchHandler;
        _ops = new List<Func<Payload<object>, Task>>
        {
            Invoke,
            Identify,
            Heartbeat,
            Disconnect
        };
    }

    public Task Handle(byte[] payload)
    {
        Console.WriteLine("PayloadReceiveHandler.Handle");
        var payloadString = Encoding.UTF8.GetString(payload).TrimEnd('\0');
        var payloadObject = JsonSerializer
            .Deserialize<Payload<object>>(payloadString);

        Console.WriteLine(
                $"Received message: {payloadString}");

        if (payloadObject == null)
            throw new ArgumentNullException();

        var op = payloadObject.op;
        var handler = _ops[(int)op];
        if (handler == null)
            throw new ArgumentNullException();

        return handler(payloadObject);
    }

    public Task Invoke(Payload<object> payload)
    {
        return _invokeHandler.Handle(payload);
    }

    public Task Disconnect(Payload<object> payload)
    {
        Console.WriteLine("PayloadReceiveHandler.Disconnect");
        return Task.CompletedTask;
    }

    public Task Heartbeat(Payload<object> payload)
    {
        Console.WriteLine("PayloadReceiveHandler.Heartbeat");
        return Task.CompletedTask;
    }

    public Task Identify(Payload<object> payload)
    {
        Console.WriteLine("PayloadReceiveHandler.Identify");
        return Task.CompletedTask;
    }
}
