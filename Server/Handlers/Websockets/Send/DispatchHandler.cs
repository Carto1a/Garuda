using System.Text.Json;
using Domain.Entities.Payloads.Dispatch;
using Server.Entities.Servers;
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

    public Task DisconnectedMethod(WebsocketConnection ws)
    {
        Console.WriteLine("DispatchHandler.Disconnected");
        if (ws.User == null) return Task.CompletedTask;

        var disconnected = Disconnected.Create(ws.User, DateTime.Now);
        var Room = ws.AtualRoom;
        if (Room == null) return Task.CompletedTask;
        return BroadcastToRoom<Disconnected>(disconnected, Room);
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
        return _payloadSendHandler.Handle(ws.ws, ready.Serialize());
    }

    public Task BroadcastToRoom<T>(
        Dispatch<T> data,
        RoomEntity room)
    {
        Console.WriteLine("DispatchHandler.BroadcastToRoom");
        var payload = data.Serialize();
        // TODO: mudar?
        foreach (var connection in room.Connections.Values)
        {
            _payloadSendHandler.Handle(connection.ws, payload);
        }
        return Task.CompletedTask;
    }

    public Task BroadcastToUser<T>(
        Dispatch<T> data,
        WebsocketConnection ws,
        Guid userId)
    {
        Console.WriteLine("DispatchHandler.BroadcastToUser");
        return Task.CompletedTask;
    }

    public Task BroadcastToServer<T>(
        Dispatch<T> data, WebsocketConnection ws)
    {
        Console.WriteLine("DispatchHandler.BroadcastToServer");
        return Task.CompletedTask;
    }

    public Task BroadcastToRooms<T>(
        Dispatch<T> data,
        WebsocketConnection ws,
        List<Guid> roomIds)
    {
        Console.WriteLine("DispatchHandler.BroadcastToRooms");
        return Task.CompletedTask;
    }

    public Task RoomListMethod(string data, WebsocketConnection ws)
    {
        Console.WriteLine("DispatchHandler.RoomList");
        var rooms = ServerEntity.Instance.ListRooms();
        var payload = RoomList.Create(rooms.Result);
        return _payloadSendHandler.Handle(ws.ws, payload.Serialize());
    }
}
