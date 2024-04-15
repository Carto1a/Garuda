using Domain.Entities.Payloads;

namespace Server.Handlers.Websockets.Receive.Interfaces;

public interface IInvokeHandler
{
    Task Handle(Payload<object> payload);
    Task MessageCreate(Payload<object> payload);
    Task MessageUpdate(Payload<object> payload);
    Task MessageDelete(Payload<object> payload);
    Task Join(Payload<object> payload);
    Task Leave(Payload<object> payload);
}
