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
        var data = Deserialize<JoinData>(payload);
        if (data == null)
            throw new ArgumentNullException();

        var roomId = data.room_id;
        if (roomId == null)
            throw new ArgumentNullException();

        var RoomCollection = ServerEntity.Instance.Rooms;
        if (RoomCollection == null)
            throw new ArgumentNullException();

        var room = (RoomEntity)RoomCollection[roomId];
        if (room == null)
            throw new ArgumentNullException();

        ws.AtualRoom = null;
        room.Join(ws);
        ws.AtualRoom = room;

        var joined =
            JoinedData.Create(room.Id, ws.User.Username);
        return _dispatchHandler.BroadcastToRoom<JoinedData>(joined, room);
    }

    public Task Leave(
        Payload<object> payload, WebsocketConnection ws)
    {
        Console.WriteLine("InvokeHandler.Leave");
        var data = Deserialize<LeaveData>(payload);
        if (data == null)
            throw new ArgumentNullException();

        var roomId = data.room_id;
        if (roomId == null)
            throw new ArgumentNullException();

        var roomCollection = ServerEntity.Instance.Rooms;
        if (roomCollection == null)
            throw new ArgumentNullException();

        var room = (RoomEntity)roomCollection[roomId];
        if (room == null)
            throw new ArgumentNullException();

        room.Leave(ws);
        ws.AtualRoom = null;
        var lefted = LeftedData.Create(ws.User.Username, room.Id);
        return _dispatchHandler.BroadcastToRoom<LeftedData>(lefted, room);
    }

    public Task MessageCreate(
        Payload<object> payload, WebsocketConnection ws)
    {
        Console.WriteLine("InvokeHandler.MessageCreate");
        var data = Deserialize<MessageCreateData>(payload);
        if (data == null)
            throw new ArgumentNullException();

        var roomId = data.room_id;
        if (roomId == null)
            throw new ArgumentNullException();

        var RoomCollection = ServerEntity.Instance.Rooms;
        if (RoomCollection == null)
            throw new ArgumentNullException();

        var room = (RoomEntity)RoomCollection[(Guid)roomId];
        if (room == null)
            throw new ArgumentNullException();

        var message = MessageEntity.Create(
            room.Id,
            ws.User.ServerUserId,
            data.content
        );

        room.Message(message);

        var payloadMessage = MessageCreatedData.Create(
            message.Id,
            ws.User.Username,
            message.Content,
            message.RoomId,
            message.CreatedAt
        );

        return _dispatchHandler
            .BroadcastToRoom<MessageCreatedData>(payloadMessage, room);
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

