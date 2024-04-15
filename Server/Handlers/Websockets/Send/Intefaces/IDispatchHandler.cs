using Server.Entities.Websocket.Connections;

namespace Server.Handlers.Websockets.Receive.Interfaces;
public interface IDispatchHandler
{
    Task Handle(string data);
    Task MessageCreatedMethod(string data, WebsocketConnection ws);
    Task MessageUpdatedMethod(string data, WebsocketConnection ws);
    Task MessageDeletedMethod(string data, WebsocketConnection ws);
    Task JoinedMethod(string data, WebsocketConnection ws);
    Task ReadyMethod(string data, WebsocketConnection ws);
    Task LeftedMethod(string data, WebsocketConnection ws);
    Task DisconnectedMethod(string data, WebsocketConnection ws);
}
