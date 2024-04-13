namespace Server.Handlers.Websockets.Intefaces;
public interface IDispatchHandler
{
    Task Handle(string data);
    Task MessageCreated(string data);
    Task MessageUpdated(string data);
    Task MessageDeleted(string data);
    Task Joined(string data);
    Task Lefted(string data);
    Task Disconnected(string data);
}
