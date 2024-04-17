using System.Net.WebSockets;
using Domain.Entities.Servers.Users.Informations;

namespace Client.Services.Intefaces;
public interface IWebsocketService
{
    Task Handle(UserSimpleInfo? user);
    Task<WebSocketReceiveResult?> GetPayload(WebSocket ws, byte[] buffer);
}
