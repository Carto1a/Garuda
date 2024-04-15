namespace Server.Entities.Websocket.Connections;
public class WebsocketConnections
{
    private static WebsocketConnections _instance =
        new WebsocketConnections();
    private static IList<WebsocketConnection> _conections =
        new List<WebsocketConnection>();

    public static WebsocketConnections Instance => _instance;
    public IList<WebsocketConnection> Connections => _conections;

    private WebsocketConnections() { }

    public void Add(WebsocketConnection ws)
    {
        _conections.Add(ws);
    }

    public void Remove(WebsocketConnection ws)
    {
        _conections.Remove(ws);
    }
}
