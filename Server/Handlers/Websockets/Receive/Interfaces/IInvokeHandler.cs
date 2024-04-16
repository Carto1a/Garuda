using Domain.Entities.Payloads;
using Server.Entities.Websocket.Connections;

namespace Server.Handlers.Websockets.Receive.Interfaces;

public interface IInvokeHandler
{
    Task Handle(Payload<object> payload, WebsocketConnection ws);
    Task MessageCreate(Payload<object> payload, WebsocketConnection ws);
    Task MessageUpdate(Payload<object> payload, WebsocketConnection ws);
    Task MessageDelete(Payload<object> payload, WebsocketConnection ws);
    Task Join(Payload<object> payload, WebsocketConnection ws);
    Task Leave(Payload<object> payload, WebsocketConnection ws);
}
