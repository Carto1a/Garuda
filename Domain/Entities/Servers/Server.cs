using Domain.Entities.Servers.Users.Informations;

namespace Domain.Entities.Servers;
public class Server
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public IDictionary<Guid, Room>? Rooms { get; set; }
    public IDictionary<Guid, UserSimpleInfo>? Users { get; set; }

    public Server(
        Guid id,
        string name,
        string? description)
    {
        // NOTE: Client give the server a id
        Id = id;
        Name = name;
        Description = description;
    }
}
