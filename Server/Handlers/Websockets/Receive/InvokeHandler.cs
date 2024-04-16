using System.Text.Json;
using Domain.Entities.Payloads;
using Domain.Entities.Payloads.Dispatch;
using Domain.Entities.Payloads.Invoke;
using Domain.Enums.Payloads;
using Server.Entities.Servers;
using Server.Entities.Websocket.Connections;
using Server.Handlers.Websockets.Receive.Interfaces;

namespace Server.Handlers.Websockets.Receive;
public class InvokeHandler
: IInvokeHandler
{
    private readonly IDictionary<string, Func<Payload<object>, WebsocketConnection, Task>> _handler;
    private readonly IDispatchHandler _dispatchHandler;
    public InvokeHandler(
        IDispatchHandler dispatchHandler)
    {
        _dispatchHandler = dispatchHandler;
        _handler = new Dictionary<string, Func<Payload<object>, WebsocketConnection, Task>>
        {
            [nameof(InvokeEvents.MESSAGE_CREATE)] = MessageCreate,
            [nameof(InvokeEvents.MESSAGE_UPDATE)] = MessageUpdate,
            [nameof(InvokeEvents.MESSAGE_DELETE)] = MessageDelete,
            [nameof(InvokeEvents.JOIN)] = Join,
            [nameof(InvokeEvents.LEAVE)] = Leave,
        };
    }

    public Task Handle(
        Payload<object> payload, WebsocketConnection ws)
    {
        Console.WriteLine("InvokeHandler.Handle");
        var type = payload.t;
        if (type == null)
            throw new ArgumentNullException();

        var func = _handler[type];
        if (func == null)
            throw new NotImplementedException();

        return func(payload, ws);
    }

    private T? Deserialize<T>(Payload<object> payload)
    {
        var data = payload.d?.ToString();
        if (data == null)
            throw new ArgumentNullException();

        return JsonSerializer.Deserialize<T>(data);
    }

    public Task Join(
        Payload<object> payload, WebsocketConnection ws)
    {
        Console.WriteLine("InvokeHandler.Join");
        var data = Deserialize<Join>(payload);
        if (data == null)
            throw new ArgumentNullException();

        var room = (RoomEntity)ServerEntity.Instance.Rooms[data.room_id];
        if (room == null)
            throw new ArgumentNullException();

        ws.AtualRoom = null;
        room.Join(ws);
        ws.AtualRoom = room;

        var joined =
            Joined.Create(room.Id, ws.User.Username);
        return _dispatchHandler.BroadcastToRoom<Joined>(joined, room);
    }

    public Task Leave(
        Payload<object> payload, WebsocketConnection ws)
    {
        Console.WriteLine("InvokeHandler.Leave");
        var data = Deserialize<Leave>(payload);
        if (data == null)
            throw new ArgumentNullException();
        var room = (RoomEntity)ServerEntity.Instance.Rooms[data.room_id];
        if (room == null)
            throw new ArgumentNullException();

        room.Leave(ws);
        ws.AtualRoom = null;
        var lefted = Lefted.Create(ws.User.Username, room.Id);
        return _dispatchHandler.BroadcastToRoom<Lefted>(lefted, room);
    }

    public Task MessageCreate(
        Payload<object> payload, WebsocketConnection ws)
    {
        Console.WriteLine("InvokeHandler.MessageCreate");
        return Task.CompletedTask;
    }

    public Task MessageDelete(
        Payload<object> payload, WebsocketConnection ws)
    {
        Console.WriteLine("InvokeHandler.MessageDelete");
        return Task.CompletedTask;
    }

    public Task MessageUpdate(
        Payload<object> payload, WebsocketConnection ws)
    {
        Console.WriteLine("InvokeHandler.MessageUpdate");
        return Task.CompletedTask;
    }
}

