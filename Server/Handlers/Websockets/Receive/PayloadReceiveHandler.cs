using System.Net.WebSockets;
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
            Heartbeat,
            Identify,
            null,
            null,
            null,
            Disconnect
        };
    }

    public Task Handle(
        byte[] payload,
        WebsocketConnection ws,
        WebSocketReceiveResult payloadInfo)
    {
        Console.WriteLine("PayloadReceiveHandler.Handle");
        var payloadString = Encoding.UTF8.GetString(
            payload.Take(payloadInfo.Count).ToArray());
        Console.WriteLine(
            $"Received message: {payloadString}");
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

    public Task Invoke(
        Payload<object> payload, WebsocketConnection ws)
    {
        return _invokeHandler.Handle(payload, ws);
    }

    public Task Disconnect(
        Payload<object> payload, WebsocketConnection ws)
    {
        Console.WriteLine("PayloadReceiveHandler.Disconnect");
        return _dispatchHandler.DisconnectedMethod(ws);
    }

    public Task Heartbeat(
        Payload<object> payload, WebsocketConnection ws)
    {
        Console.WriteLine("PayloadReceiveHandler.Heartbeat");
        ws.RestartHeartbeat();
        return _payloadSendHandler.HeartbeatAck(ws);
    }

    public Task Identify(
        Payload<object> payload, WebsocketConnection ws)
    {
        Console.WriteLine("PayloadReceiveHandler.Identify");
        // TODO: Enviar errro
        if (ws.IsIdentified)
            throw new InvalidOperationException();

        var data = payload.d?.ToString();
        if (data == null)
            throw new ArgumentNullException();

        var request = JsonSerializer.Deserialize<IdentifyPayload>(data);
        if (request == null)
            throw new ArgumentNullException();

        UserSimpleAuthenticateDto? user = null;
        if (!request.Anonymous)
        {
            user = new UserSimpleAuthenticateDto
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email
            };
        }

        ws.Indentify(user, request.Anonymous);
        return Task.CompletedTask;
    }
}
