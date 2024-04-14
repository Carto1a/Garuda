using System.Net.WebSockets;

namespace Server.Entities.Websocket;
public class WebsocketConnectionsIdentified
{
    private static WebsocketConnectionsIdentified _instance =
        new WebsocketConnectionsIdentified();
    private static IList<WebSocket> _conections = new List<WebSocket>();

    public static WebsocketConnectionsIdentified Instance => _instance;
    public IList<WebSocket> Connections => _conections;

    private WebsocketConnectionsIdentified() { }
}
