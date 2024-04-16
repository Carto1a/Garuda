using Domain.Entities.Servers;
using Domain.Entities.Servers.Messages;
using Domain.Entities.Servers.Users.Informations;
using Server.Entities.Websocket.Connections;

namespace Server.Entities.Servers;
public class RoomEntity
: Room
{
    public IDictionary<Guid, WebsocketConnection> Connections { get; } = new Dictionary<Guid, WebsocketConnection>();

    public RoomEntity(
        Guid id,
        string? name,
        string? description)
    : base(id, name, description)
    {
        Messages = new List<Message>();
        Users = new Dictionary<Guid, UserSimpleInfo>();
    }

    public Task Message(Message message)
    {
        // TODO: verificar as lista, se elas foi inicializada
        Messages?.Add(message);
        return Task.CompletedTask;
    }

    public Task Join(WebsocketConnection ws)
    {
        Connections.Add(ws.Id, ws);
        Users?.Add(ws.Id, ws.User);
        return Task.CompletedTask;
    }

    public Task Leave(WebsocketConnection ws)
    {
        Connections.Remove(ws.Id);
        return Task.CompletedTask;
    }
}
