using Domain.Entities.Payloads.Dispatch;

namespace Server.Handlers.Websockets.Intefaces;
public interface IDispatchHandler
{
    Task Handle(Dispatch data);
    Task MessageCreated(Dispatch data);
    Task MessageUpdated(Dispatch data);
    Task MessageDeleted(Dispatch data);
    Task Joined(Dispatch data);
    Task Lefted(Dispatch data);
    Task Disconnected(Dispatch data);
}
