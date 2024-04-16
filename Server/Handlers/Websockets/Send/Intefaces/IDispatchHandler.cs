using Domain.Entities.Payloads.Dispatch;
using Server.Entities.Servers;
using Server.Entities.Websocket.Connections;

namespace Server.Handlers.Websockets.Receive.Interfaces;
public interface IDispatchHandler
{
    Task Handle(string data);
    Task BroadcastToRoom<T>(Dispatch<T> data, RoomEntity Room);
    Task BroadcastToUser<T>(Dispatch<T> data, WebsocketConnection ws, Guid UserId);
    Task BroadcastToServer<T>(Dispatch<T> data, WebsocketConnection ws);
    Task BroadcastToRooms<T>(Dispatch<T> data, WebsocketConnection ws, List<Guid> RoomIds);
    Task MessageCreatedMethod(string data, WebsocketConnection ws);
    Task MessageUpdatedMethod(string data, WebsocketConnection ws);
    Task MessageDeletedMethod(string data, WebsocketConnection ws);
    Task JoinedMethod(string data, WebsocketConnection ws);
    Task ReadyMethod(string data, WebsocketConnection ws);
    Task LeftedMethod(string data, WebsocketConnection ws);
    Task DisconnectedMethod(WebsocketConnection ws);
    Task RoomListMethod(string data, WebsocketConnection ws);
}
