using System.Net.WebSockets;
using Client.Entities.Websockets;
using Domain.Entities.Payloads;

namespace Client.Handlers.Websockets.Receive.Interfaces;
public interface IPayloadReceiveHandler
{
    public Task Handle(byte[] buffer, UserConnection ws, WebSocketReceiveResult payloadInfo);
    public Task Invoke(Payload<object> payload, UserConnection ws);
    public Task Heartbeat(Payload<object> payload, UserConnection ws);
    public Task Hello(Payload<object> payload, UserConnection ws);
    public Task HeartbeatAck(Payload<object> payload, UserConnection ws);
    public Task InvalidSession(Payload<object> payload, UserConnection ws);
}
