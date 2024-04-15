using System.Net.WebSockets;
using Domain.Entities.Payloads;
using Server.Entities.Websocket.Connections;

namespace Server.Handlers.Websockets.Receive.Interfaces;
public interface IPayloadReceiveHandler
{
    Task Handle(byte[] payload, WebsocketConnection ws, WebSocketReceiveResult payloadInfo);
    Task Invoke(Payload<object> payload, WebsocketConnection ws);
    Task Heartbeat(Payload<object> payload, WebsocketConnection ws);
    Task Identify(Payload<object> payload, WebsocketConnection ws);
    Task Disconnect(Payload<object> payload, WebsocketConnection ws);
}

