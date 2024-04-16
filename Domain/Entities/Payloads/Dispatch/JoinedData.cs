using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class JoinedData
{
    public Guid room_id { get; set; }
    public string username { get; set; }
    public DateTime joined_at { get; set; }

    public JoinedData(
        Guid roomId,
        string username,
        DateTime joinedAt)
    {
        this.room_id = roomId;
        this.username = username;
        this.joined_at = joinedAt;
    }

    public static Dispatch<JoinedData> Create(
        Guid roomId,
        string username)
    {
        return new Dispatch<JoinedData>(
            nameof(DispatchEvents.JOINED),
            new JoinedData(roomId, username, DateTime.Now));
    }
}
