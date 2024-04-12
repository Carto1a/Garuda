using Domain.Entities.Payloads;

namespace Server.Handlers.Websockets.Intefaces;
public interface IPayloadHandler
{
    Task Handle(Payload<object> payload);
    Task Dispatch(Payload<object> payload);
    Task Invoke(Payload<object> payload);
    Task Heartbeat(Payload<object> payload);
    Task Identify(Payload<object> payload);
    Task Hello(Payload<object> payload);
    Task HeartbeatAck(Payload<object> payload);
    Task Disconnect(Payload<object> payload);
}
