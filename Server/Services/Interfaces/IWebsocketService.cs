using System.Net.WebSockets;

namespace Server.Services.Interfaces;
public interface IWebsocketService
{
    Task OpenWebsocket(WebSocket ws);
    Task<WebSocketReceiveResult?> GetPayload(WebSocket ws, byte[] buffer);
}
