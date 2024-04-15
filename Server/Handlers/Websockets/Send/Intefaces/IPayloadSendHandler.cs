using System.Net.WebSockets;
using Domain.Entities.Payloads;
using Server.Entities.Websocket.Connections;

namespace Server.Handlers.Websockets.Send.Interfaces;
public interface IPayloadSendHandler
{
    Task Handle(WebSocket ws, ArraySegment<byte> payload);
    Task Dispatch(Payload<object> payload);
    Task Heartbeat(WebsocketConnection ws);
    Task Hello(WebsocketConnection ws);
    Task HeartbeatAck(WebsocketConnection ws);
    Task Disconnect(WebsocketConnection ws);
}
