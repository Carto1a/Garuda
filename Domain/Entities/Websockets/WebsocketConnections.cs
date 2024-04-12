using System.Net.WebSockets;

namespace Domain.Entities.Websocket;
public class WebsocketConnections
{
    private static WebsocketConnections _instance = new WebsocketConnections();
    private static IList<WebSocket> _conections = new List<WebSocket>();

    public static WebsocketConnections Instance => _instance;
    public IList<WebSocket> Connections => _conections;

    private WebsocketConnections() { }
}
