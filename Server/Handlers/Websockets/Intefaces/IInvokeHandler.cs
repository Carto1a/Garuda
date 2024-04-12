using Domain.Entities.Payloads.Invoke;

namespace Server.Handlers.Websockets.Intefaces;
public interface IInvokeHandler
{
    Task Handle(Invoke data);
    Task MessageCreate(Invoke data);
    Task MessageUpdate(Invoke data);
    Task MessageDelete(Invoke data);
    Task Join(Invoke data);
    Task Leave(Invoke data);
    Task Disconnect(Invoke data);
}
