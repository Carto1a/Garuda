using System.Text.Json;
using Domain.Entities.Payloads.Dispatch;
using Server.Entities.Websocket.Connections;
using Server.Handlers.Websockets.Receive.Interfaces;
using Server.Handlers.Websockets.Send.Interfaces;

namespace Server.Handlers.Websockets.Send;
public class DispatchHandler
: IDispatchHandler
{
    private readonly IPayloadSendHandler _payloadSendHandler;
    public DispatchHandler(
        IPayloadSendHandler payloadSendHandler
    )
    {
        _payloadSendHandler = payloadSendHandler;
    }

    public Task Handle(string data)
    {
        Console.WriteLine("DispatchHandler.Handle");
        return Task.CompletedTask;
    }

    public Task DisconnectedMethod(string data, WebsocketConnection ws)
    {
        Console.WriteLine("DispatchHandler.Disconnected");
        var disconnected = Disconnected.Create(Guid.NewGuid(), DateTime.Now);
        return _payloadSendHandler.Handle(ws.ws, JsonSerializer.SerializeToUtf8Bytes(disconnected));
    }

    public Task JoinedMethod(string data, WebsocketConnection ws)
    {
        Console.WriteLine("DispatchHandler.Joined");
        return Task.CompletedTask;
    }

    public Task LeftedMethod(string data, WebsocketConnection ws)
    {
        Console.WriteLine("DispatchHandler.Lefted");
        return Task.CompletedTask;
    }

    public Task MessageCreatedMethod(string data, WebsocketConnection ws)
    {
        Console.WriteLine("DispatchHandler.MessageCreated");
        return Task.CompletedTask;
    }

    public Task MessageDeletedMethod(string data, WebsocketConnection ws)
    {
        Console.WriteLine("DispatchHandler.MessageDeleted");
        return Task.CompletedTask;
    }

    public Task MessageUpdatedMethod(string data, WebsocketConnection ws)
    {
        Console.WriteLine("DispatchHandler.MessageUpdated");
        return Task.CompletedTask;
    }

    public Task ReadyMethod(string data, WebsocketConnection ws)
    {
        Console.WriteLine("DispatchHandler.Ready");
        var ready = Ready.Create();
        return _payloadSendHandler.Handle(ws.ws, JsonSerializer.SerializeToUtf8Bytes(ready));
    }
}
