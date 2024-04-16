using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class LeftedData
{
    public Guid room_id { get; set; }
    public string username { get; set; }
    public DateTime left_at { get; set; }

    public LeftedData(
        string username,
        Guid roomId,
        DateTime leftAt)
    {
        this.username = username;
        this.left_at = leftAt;
        this.room_id = roomId;
    }

    public static Dispatch<LeftedData> Create(
        string username,
        Guid roomId)
    {
        return new Dispatch<LeftedData>(
            nameof(DispatchEvents.LEFTED),
            new LeftedData(username, roomId, DateTime.Now));
    }
}
