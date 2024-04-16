using System.Net.WebSockets;

namespace Client.Services.Intefaces;
public interface IWebsocketService
{
    Task Handle();
    Task<WebSocketReceiveResult?> GetPayload(WebSocket ws, byte[] buffer);
}
