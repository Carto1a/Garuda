using System.Net.WebSockets;
using Domain.Entities.Payloads;
using Domain.Entities.Payloads.Dispatch;
using Server.Entities.Websocket.Connections;

namespace Server.Handlers.Websockets.Send.Interfaces;
public interface IPayloadSendHandler
{
    Task Handle(WebSocket ws, ArraySegment<byte> payload);
    Task Dispatch(Dispatch<object> data, WebsocketConnection ws);
    Task Heartbeat(WebsocketConnection ws);
    Task Hello(WebsocketConnection ws);
    Task HeartbeatAck(WebsocketConnection ws);
    Task InvalidSession(Payload<InvalidSessionPayload> data, WebsocketConnection ws);
    Task Disconnect(Dispatch<DisconnectedData> data, WebsocketConnection ws);
}
