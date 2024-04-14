using Domain.Entities.Payloads;

namespace Server.Handlers.Websockets.Receive.Interfaces;
public interface IPayloadReceiveHandler
{
    Task Handle(byte[] payload);
    Task Invoke(Payload<object> payload);
    Task Heartbeat(Payload<object> payload);
    Task Identify(Payload<object> payload);
    Task Disconnect(Payload<object> payload);
}

