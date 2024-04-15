using System.Text;
using System.Text.Json;
using Domain.Dtos.Websockets;
using Domain.Entities.Payloads;
using Server.Entities.Websocket.Connections;
using Server.Handlers.Websockets.Receive.Interfaces;
using Server.Handlers.Websockets.Send.Interfaces;

namespace Server.Handlers.Websockets.Receive;
public class PayloadReceiveHandler
: IPayloadReceiveHandler
{
    private readonly IInvokeHandler _invokeHandler;
    private readonly IDispatchHandler _dispatchHandler;
    private readonly IPayloadSendHandler _payloadSendHandler;
    private readonly IList<Func<Payload<object>, WebsocketConnection, Task>> _ops;

    public PayloadReceiveHandler(
        IPayloadSendHandler payloadSendHandler,
        IInvokeHandler invokeHandler,
        IDispatchHandler dispatchHandler)
    {
        _invokeHandler = invokeHandler;
        _dispatchHandler = dispatchHandler;
        _payloadSendHandler = payloadSendHandler;
        _ops = new List<Func<Payload<object>, WebsocketConnection, Task>>
        {
            Invoke,
            Identify,
            Heartbeat,
            Disconnect
        };
    }

    public Task Handle(byte[] payload, WebsocketConnection ws)
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

        return handler(payloadObject, ws);
    }

    public Task Invoke(Payload<object> payload, WebsocketConnection ws)
    {
        return _invokeHandler.Handle(payload);
    }

    public Task Disconnect(Payload<object> payload, WebsocketConnection ws)
    {
        Console.WriteLine("PayloadReceiveHandler.Disconnect");
        return _payloadSendHandler.Disconnect(ws);
    }

    public Task Heartbeat(Payload<object> payload, WebsocketConnection ws)
    {
        Console.WriteLine("PayloadReceiveHandler.Heartbeat");
        return _payloadSendHandler.HeartbeatAck(ws);
    }

    public Task Identify(Payload<object> payload, WebsocketConnection ws)
    {
        Console.WriteLine("PayloadReceiveHandler.Identify");
        var request = JsonSerializer.Deserialize<IdentifyPayload>(
            JsonSerializer.Serialize(payload.d));
        UserSimpleAuthenticateDto user = new(
            request.Email, request.Password, request.Username);
        ws.Indentify(user);
        return Task.CompletedTask;
    }
}
