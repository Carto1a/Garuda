using System.Net.WebSockets;
using Domain.Entities.Payloads;

namespace Server.Handlers.Websockets.Send.Interfaces;
public interface IPayloadSendHandler
{
    Task Handle(WebSocket ws, ArraySegment<byte> payload);
    Task Dispatch(Payload<object> payload);
    Task Heartbeat(WebSocket ws, int heartbeatInterval);
    Task Hello(WebSocket ws);
    Task HeartbeatAck(WebSocket ws);
    Task Disconnect(WebSocket ws);
}
