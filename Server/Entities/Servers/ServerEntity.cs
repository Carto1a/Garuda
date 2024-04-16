using Domain.Entities.Servers;
using Domain.Entities.Servers.Users.Informations;
using Server.Entities.Websocket.Connections;

namespace Server.Entities.Servers;
public class ServerEntity
: Domain.Entities.Servers.Server
{
    private static IDictionary<Guid, WebsocketConnection> _wsConnections =
        new Dictionary<Guid, WebsocketConnection>();
    public static IDictionary<Guid, WebsocketConnection> WsConnections => _wsConnections;
    private static ServerEntity _instance = new ServerEntity("Server", "Server");
    public static ServerEntity Instance => _instance;

    public ServerEntity(
        string name,
        string? description)
    : base(Guid.Empty, name, description)
    {
        Users = new Dictionary<Guid, UserSimpleInfo>();
        Rooms = new Dictionary<Guid, Room>();
        var id = Guid.NewGuid();
        Rooms.Add(id, new Room(id, "main", "server test room"));
    }

    public Task Add(WebsocketConnection ws)
    {
        _wsConnections.Add(ws.Id, ws);
        Users?.Add(ws.Id, ws.User);
        return Task.CompletedTask;
    }

    public Task Remove(WebsocketConnection ws)
    {
        _wsConnections.Remove(ws.Id);
        return Task.CompletedTask;
    }

    public Task AddUser(UserSimpleInfo user)
    {
        Users?.Add(user.ServerUserId, user);
        return Task.CompletedTask;
    }

    public Task UpdateUser(UserSimpleInfo user)
    {
        Users[user.ServerUserId] = user;
        return Task.CompletedTask;
    }

    public Task<List<Room>> ListRooms()
    {
        // TODO: mudar?
        var rooms = new List<Room>();
        for(var i = 0; i < Rooms.Count; i++)
        {
            var room = Rooms.ElementAt(i);
            rooms.Add(room.Value);
        }
        return Task.FromResult(rooms);
    }
}

