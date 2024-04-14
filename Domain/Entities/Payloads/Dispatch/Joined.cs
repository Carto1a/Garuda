using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class Joined
{
    public Guid room_id { get; set; }
    public string username { get; set; }
    public DateTime joined_at { get; set; }

    public Joined(
        Guid roomId,
        string username,
        DateTime joinedAt)
    {
        this.room_id = roomId;
        this.username = username;
        this.joined_at = joinedAt;
    }

    public static Dispatch<Joined> Create(
        Guid roomId,
        string username,
        DateTime joinedAt)
    {
        return new Dispatch<Joined>(
            nameof(DispatchEvents.JOINED),
            new Joined(roomId, username, joinedAt));
    }
}
