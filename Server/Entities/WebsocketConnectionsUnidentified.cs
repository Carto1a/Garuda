using System.Net.WebSockets;

namespace Server.Entities.Websocket;
public class WebsocketConnectionsUnidentified
{
    private static WebsocketConnectionsUnidentified _instance =
        new WebsocketConnectionsUnidentified();
    private static IList<WebSocket> _conections = new List<WebSocket>();

    public static WebsocketConnectionsUnidentified Instance => _instance;
    public IList<WebSocket> Connections => _conections;

    private WebsocketConnectionsUnidentified() { }
}
