using Domain.Entities.Servers.Users.Informations;

namespace Domain.Entities.Servers;
public class Room
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public IDictionary<Guid, UserSimpleInfo>? Users { get; set; }
    public IList<Message>? Messages { get; set; }

    public Room(
        Guid id,
        string? name,
        string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}
