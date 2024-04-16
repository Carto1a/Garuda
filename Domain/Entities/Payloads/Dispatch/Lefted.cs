using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class Lefted
{
    public Guid room_id { get; set; }
    public string username { get; set; }
    public DateTime left_at { get; set; }

    public Lefted(
        string username,
        Guid roomId,
        DateTime leftAt)
    {
        this.username = username;
        this.left_at = leftAt;
        this.room_id = roomId;
    }

    public static Dispatch<Lefted> Create(
        string username,
        Guid roomId)
    {
        return new Dispatch<Lefted>(
            nameof(DispatchEvents.LEFTED),
            new Lefted(username, roomId, DateTime.Now));
    }
}
