namespace Server.Handlers.Websockets.Intefaces;
public interface IInvokeHandler
{
    Task Handle(string data);
    Task MessageCreate(string data);
    Task MessageUpdate(string data);
    Task MessageDelete(string data);
    Task Join(string data);
    Task Leave(string data);
    Task Disconnect(string data);
}
