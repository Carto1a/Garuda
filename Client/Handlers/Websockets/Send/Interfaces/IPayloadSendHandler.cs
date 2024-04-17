using System.Net.WebSockets;
using Client.Entities.Websockets;
using Domain.Entities.Payloads.Dispatch;

namespace Client.Handlers.Websockets.Send.Interfaces;
public interface IPayloadSendHandler
{
    public Task Handle(UserConnection ws, ArraySegment<byte> buffer);
    public Task Dispatch(Dispatch<object> data, UserConnection ws);
    public Task Heartbeat(UserConnection ws);
    public Task Identify(UserConnection ws);
}
